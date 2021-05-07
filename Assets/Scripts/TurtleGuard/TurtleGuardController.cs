using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleGuardController : Actor
{
    public GuardWalking sGuardWalking { get; protected set; }
    public GuardResting  sGuardResting { get; protected set; }

    private void Awake()
    {
        sGuardResting = new GuardResting(this);
        sGuardWalking = new GuardWalking(this);
    }

 

    // Update is called once per frame
    void Update()
    {
        
    }
}
