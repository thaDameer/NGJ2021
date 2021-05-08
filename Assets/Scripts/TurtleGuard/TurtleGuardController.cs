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
   
    [SerializeField] private Rigidbody myRigidbody;
    private Vector3 controllerVector;
    public bool isMoving;

    #region MovementVariables

    private float maxMovementSpeed => variables.maxMovementSpeed;
    private float minMovementSpeed => variables.minMovementSpeed;
    private float rotationSpeed => variables.rotationSpeed;
    private float minEnergy => variables.minEnergy;
    private float maxEnergy => variables.maxEnergy;
    

    #endregion
    private void Awake()
    {
        sGuardResting = new GuardResting(this);
        sGuardWalking = new GuardWalking(this);
        sGuardResting.OnEnterState();
    }

    public override void Update()
    {
        base.Update();
        ControllerInputs();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        Movement();
    }

    private void Movement()
    {
        myRigidbody.velocity = controllerVector.normalized * maxMovementSpeed;
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
}
