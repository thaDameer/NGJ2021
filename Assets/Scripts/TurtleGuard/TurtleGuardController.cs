using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleGuardController : Actor
{
    [SerializeField]private CharacterVariables variables;
    public GuardWalking sGuardWalking { get; protected set; }
    public GuardResting  sGuardResting { get; protected set; }
    public KeyCode upKey, downKey, leftKey, rightKey;
    private bool upKeyHold, downKeyHold, leftKeyHold, rightKeyHold;

    public Rigidbody myRigidbody;
    
    public Vector3 controllerVector { get; private set; }
    public bool isMoving;
    public bool canBePickedUp;
    #region MovementVariables

    public float maxMovementSpeed => variables.maxMovementSpeed;
    public float minMovementSpeed => variables.minMovementSpeed;
    public float rotationSpeed => variables.rotationSpeed;
    public float minEnergy => variables.minEnergy;
    public float maxEnergy => variables.maxEnergy;
    public float drainMultiplier => variables.energyDrainMultiplier;

    public float currentEnergy;

    #endregion

    private Collider[] colliders;
    private void Awake()
    {
        currentEnergy = maxEnergy;
        colliders = GetComponentsInChildren<Collider>();
        sGuardResting = new GuardResting(this);
        sGuardWalking = new GuardWalking(this);
        sGuardWalking.OnEnterState();
    }

    public override void Update()
    {
        base.Update();
        ControllerInputs();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        
       
    }

    public bool TryGoToRestingState(Transform chairParent)
    {
        if(!canBePickedUp) return false;
        transform.parent = chairParent;
        Vector3 sittingPos = Vector3.zero;
        sittingPos.y += 0.4f;
        transform.localPosition = sittingPos;
        transform.rotation = chairParent.transform.rotation;
        sGuardResting.OnEnterState();
        return true;
    }
    public void ToggleGuardColliders(bool isActive)
    {
        foreach (var collider in colliders)
        {
            collider.enabled = isActive;
        }
    }

    IEnumerator ThrowDelay_CO()
    {
        yield return new WaitForSeconds(0.3f);
        ToggleGuardColliders(true);
    }
    public void PutDownGuard(Transform chairObject)
    {
        transform.parent = null;
        var throwDirection = chairObject.transform.forward;
        throwDirection.y += 0.3f;
        myRigidbody.isKinematic = false;
        myRigidbody.AddForce(throwDirection * 10,ForceMode.Impulse);
        isThrown = true;
        StartCoroutine(ThrowDelay_CO());
        //var guardPos = (chairObject.transform.forward * 1.5f + chairObject.transform.position);
        //transform.position = guardPos;


    }

    public bool isThrown;
    IEnumerator GuardThrow_CO()
    {
        
        yield return new WaitForSeconds(0.5f);
        sGuardWalking.OnEnterState();
    }
    private void ControllerInputs()
    {
        float xMovement = 0;
        float zMovement = 0;
        
        upKeyHold = Input.GetKey(upKey);
        downKeyHold = Input.GetKey(downKey);
        leftKeyHold = Input.GetKey(leftKey);
        rightKeyHold = Input.GetKey(rightKey);
        isMoving = upKeyHold || (downKeyHold || (leftKeyHold || (rightKeyHold ? true : false)));
        if (leftKeyHold)
            xMovement = -1;
        else if (rightKeyHold)
            xMovement = 1;
        if (upKeyHold)
            zMovement = 1;
        else if (downKeyHold)
            zMovement = -1;

        controllerVector = new Vector3(xMovement, 0, zMovement);
    }

    public void DrainingEnergy()
    {
       currentEnergy -= drainMultiplier * Time.fixedDeltaTime;
       ClampCurrentEnergy();
       var percent = GetEnergyPercent();
       UIManager.Instance.UpdateGuardDrainingMeter(percent, transform);
    }

    public void GainingEnergy()
    {
        currentEnergy += (drainMultiplier * 1.5f) * Time.fixedDeltaTime;
        ClampCurrentEnergy();
        var percent = GetEnergyPercent();
        UIManager.Instance.UpdateRestingMeter(percent,transform);
    }
    void ClampCurrentEnergy()
    {
        currentEnergy = Mathf.Clamp(currentEnergy, 0, maxEnergy);
    }
    public float GetEnergyPercent()
    {
        return currentEnergy / maxEnergy;
    }

    public float GetGuardSpeed()
    {
        return Mathf.Lerp(minMovementSpeed, maxMovementSpeed, GetEnergyPercent());
    }
}
