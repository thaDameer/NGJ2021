using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChairController : MonoBehaviour
{
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] private Transform pivot;
    [SerializeField] private float rotationSpeed = 10f;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform chairObject;
    public KeyCode leftKey;
    public KeyCode rightKey;
    public KeyCode upKey;
    public KeyCode downKey;
    private bool leftKeyHold;
    private bool rightKeyHold;
    private bool upKeyHold;
    private bool downKeyHold;
    
    private void Update()
    {
        leftKeyHold = Input.GetKey(leftKey);
        rightKeyHold = Input.GetKey(rightKey);
        upKeyHold = Input.GetKey(upKey);
        downKeyHold = Input.GetKey(downKey);

        var spherePos = myRigidbody.transform.position;
        chairObject.position = myRigidbody.transform.position;
    }

    private void FixedUpdate()
    {
        if (upKeyHold)
        {
            myRigidbody.AddForce(pivot.transform.forward * moveSpeed);
        }else if (downKeyHold)
        {
            myRigidbody.AddForce(pivot.transform.forward * -moveSpeed);
        }
        if (rightKeyHold)
        {
            var testVelocity = pivot.transform.forward * myRigidbody.velocity.magnitude;
            myRigidbody.velocity = testVelocity;
            pivot.transform.Rotate(pivot.up * rotationSpeed);
        }else if (leftKeyHold)
        {
            var testVelocity = pivot.transform.forward * myRigidbody.velocity.magnitude;
            myRigidbody.velocity = testVelocity;
            pivot.transform.Rotate(pivot.up*-rotationSpeed);
        }
    }

    private void RotateChair()
    {
        
    }
}
