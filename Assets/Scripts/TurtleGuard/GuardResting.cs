using System.Collections;
using System.Collections.Generic;
using States;
using UnityEngine;

public class GuardResting : State
{
    private TurtleGuardController actor;
    public GuardResting(TurtleGuardController actor) : base(actor)
    {
        this.actor = actor;
    }

    public override void OnEnterState()
    {
        base.OnEnterState();
        actor.myRigidbody.isKinematic = true;
    }

    public override void OnExitState()
    {
        base.OnExitState();
        actor.myRigidbody.isKinematic = false;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
