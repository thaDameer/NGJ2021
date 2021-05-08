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
        actor.sleepParticle.Play();
        actor.animator.SetTrigger("isResting");
    }

    public override void OnExitState()
    {
        base.OnExitState();
        actor.ToggleGuardColliders(true);
        actor.myRigidbody.isKinematic = false;
        actor.sleepParticle.Stop();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        actor.GainingEnergy();
    }

    public override void OnCollisionEnter(Collision coll)
    {
        base.OnCollisionEnter(coll);
        if(actor.isThrown)
            actor.sGuardWalking.OnEnterState();
    }

   
}
