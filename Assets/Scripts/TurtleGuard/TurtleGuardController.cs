using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleGuardController : Actor
{
    public GuardWalking sGuardWalking { get; protected set; }
    public GuardResting  sGuardResting { get; protected set; }
    public KeyCode upKey, downKey, leftKey, rightKey;
    private bool upKeyHold, downKeyHold, leftKeyHold, rightKeyHold;
    [SerializeField]private float  movementSpeed;
    [SerializeField] private Rigidbody myRigidbody;
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
        
    }

    private void Movement()
    {
        //var controllerVector = new Vector3()
    }
    private void ControllerInputs()
    {
        upKeyHold = Input.GetKey(upKey);
        downKeyHold = Input.GetKey(downKey);
        leftKeyHold = Input.GetKey(leftKey);
        rightKeyHold = Input.GetKey(rightKey);
    }
}
