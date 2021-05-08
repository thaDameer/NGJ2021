using System.Collections;
using System.Collections.Generic;
using States;
using UnityEngine;

public class GuardResting : State
{
    public TurtleGuardController actor;
    public GuardResting(TurtleGuardController actor) : base(actor)
    {
        this.actor = actor;
    }

    public override void OnEnterState()
    {
        base.OnEnterState();
        actor.ToggleGuardColliders(false);
        actor.myRigidbody.isKinematic = true;
    }

    public override void OnExitState()
    {
        base.OnExitState();
        actor.ToggleGuardColliders(true);
        actor.myRigidbody.isKinematic = false;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }
}
