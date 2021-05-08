using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class ChairController : MonoBehaviour
{
    [SerializeField] private CharacterVariables variables;
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] private Transform pivot;
  
    [SerializeField] private Transform chairObject;
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode upKey;
    public KeyCode downKey;
    public KeyCode interactButton;
    private bool leftKeyHold;
    private bool rightKeyHold;
    private bool upKeyHold;
    private bool downKeyHold;
    private bool interactButtonDown;
    
    [SerializeField]private ParticleSystem boostParticle;

    private float currentSpeed;
    public float CurrentSpeed => currentSpeed;
    bool isAccelerating;
    public float boost = 5;
    [Range(0.1f,0.99f)]
    public float decelerateValue;

    [SerializeField] private PickUpCollider pickUpCollider;
    public bool guardInZone => pickUpCollider.turtleGuardInZone;
    private bool guardIsPickedUp;
    //[SerializeField] private CarryingIcon carryingIcon;

    private Collider[] colliders;
    
    #region MovementVariables
    
    private float rotationSpeed =>variables.rotationSpeed;
    private float maxMoveSpeed => variables.maxMovementSpeed;
    private float minMoveSpeed => variables.minMovementSpeed;
    private float minEnergy => variables.minEnergy;
    private float maxEnergy => variables.maxEnergy;
    

    #endregion

    private bool isBoosted;
    [SerializeField] private float boostDuration = 8f;
    private float boostTimer = 0;
    private void Start()
    {
        //carryingIcon.gameObject.SetActive(false);
        colliders = GetComponentsInChildren<Collider>();
        boostParticle.Stop();
    }

   
    private void Update()
    {
      ControllerInputs();

      if (!guardIsPickedUp && guardInZone)
      {
          var turtleGuard = GameManager.Instance.GuardController;
          var pickedUp = turtleGuard.TryGoToRestingState(chairObject);
         
          guardIsPickedUp = pickedUp;
      }

      if (guardIsPickedUp&&interactButtonDown)
      {
          var turtleGuard = GameManager.Instance.GuardController;
          turtleGuard.PutDownGuard(chairObject);
        
          pickUpCollider.turtleGuardInZone = false;
          guardIsPickedUp = false;
      }    
    }

   
    void ControllerInputs()
    {
        if(!isBoosted)
            currentSpeed = minMoveSpeed;
        else
        {
            if (boostTimer < boostDuration)
            {
                boostTimer += Time.deltaTime;
                var percent = boostTimer / boostDuration;
                currentSpeed = Mathf.Lerp(maxMoveSpeed, minMoveSpeed, percent);
            }
            else
            {
                isBoosted = false;
                boostParticle.Stop();
            }
        }
        
        chairObject.position = myRigidbody.transform.position;
        leftKeyHold = Input.GetKey(leftKey);
        rightKeyHold = Input.GetKey(rightKey);
        upKeyHold = Input.GetKey(upKey);
        downKeyHold = Input.GetKey(downKey);
        interactButtonDown = Input.GetKeyDown(interactButton);
    }
    private void FixedUpdate()
    {
        if (upKeyHold)
        {
            isAccelerating = true;
            var velocity = pivot.transform.forward * currentSpeed;
            velocity.y = myRigidbody.velocity.y;
            myRigidbody.velocity = velocity;
        }else if (downKeyHold)
        {
            isAccelerating = true;
            var velocity = pivot.transform.forward * -currentSpeed;
            velocity.y = myRigidbody.velocity.y;
            myRigidbody.velocity = velocity;
        }
        else
            isAccelerating = false;

        if (!isAccelerating)
        {
            if (isBoosted)
            {
                if (upKeyHold)
                {
                    var velocity = myRigidbody.velocity.magnitude * pivot.transform.forward;
                    var yVel = myRigidbody.velocity.y;
                    myRigidbody.velocity = new Vector3(velocity.x, yVel, velocity.z);
                }else if (downKeyHold)
                {
                    
                }
               
            }
            
        }
        RotateChair();
    }

    public void GetBoost()
    {
        isBoosted = true;
        boostParticle.Play();
        boostTimer = 0;
        myRigidbody.AddForce(chairObject.transform.forward * boost,ForceMode.Impulse);
        currentSpeed = maxMoveSpeed;

    }
    private void RotateChair()
    {
        
        if (rightKeyHold)
        {
            pivot.transform.Rotate(pivot.up * rotationSpeed);
        }else if (leftKeyHold)
        {
         
            
            pivot.transform.Rotate(pivot.up*-rotationSpeed);
        }
    }
}
