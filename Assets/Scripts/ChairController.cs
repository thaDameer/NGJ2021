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
    public KeyCode boostKey;
    private bool leftKeyHold;
    private bool rightKeyHold;
    private bool upKeyHold;
    private bool downKeyHold;
    private bool boostHold;

    private float currentSpeed;
    bool isAccelerating;
    public float boost = 5;
    [Range(0.1f,0.99f)]
    public float decelerateValue;

    #region MovementVariables
    
    private float rotationSpeed =>variables.rotationSpeed;
    private float maxMoveSpeed => variables.maxMovementSpeed;
    private float minMoveSpeed => variables.maxMovementSpeed;
    private float minEnergy => variables.minEnergy;
    private float maxEnergy => variables.maxEnergy;
    

    #endregion
    private void Update()
    {
      ControllerInputs();
    }

    void ControllerInputs()
    {
        if (boostHold)
            currentSpeed = maxMoveSpeed + boost;
        else
            currentSpeed = maxMoveSpeed;
        
        chairObject.position = myRigidbody.transform.position;
        leftKeyHold = Input.GetKey(leftKey);
        rightKeyHold = Input.GetKey(rightKey);
        upKeyHold = Input.GetKey(upKey);
        downKeyHold = Input.GetKey(downKey);
        boostHold = Input.GetKey(boostKey);
    }
    private void FixedUpdate()
    {
        if (upKeyHold)
        {
            isAccelerating = true;
            myRigidbody.AddForce(pivot.transform.forward * currentSpeed);
        }else if (downKeyHold)
        {
            isAccelerating = true;
            myRigidbody.AddForce(pivot.transform.forward * -currentSpeed);
        }
        else
            isAccelerating = false;

        if (!isAccelerating)
        {
            var decelerate = (myRigidbody.velocity*decelerateValue);

            decelerate.y = myRigidbody.velocity.y;
            myRigidbody.velocity = decelerate;
        }
        RotateChair();
    }

    private void RotateChair()
    {
        
        if (rightKeyHold)
        {
            var testVelocity = pivot.transform.forward * myRigidbody.velocity.magnitude;
            // myRigidbody.velocity = testVelocity;
            // var rotation = Quaternion.Euler(pivot.up * rotationSpeed);
            // rotation.x = 0;
            // rotation.z = 0;
            // pivot.transform.rotation = Quaternion.Slerp(pivot.transform.rotation,rotation,1 * Time.fixedTime);
            pivot.transform.Rotate(pivot.up * rotationSpeed);
        }else if (leftKeyHold)
        {
            var testVelocity = pivot.transform.forward * myRigidbody.velocity.magnitude;
            myRigidbody.velocity = testVelocity;
            pivot.transform.Rotate(pivot.up*-rotationSpeed);
        }
    }
}
