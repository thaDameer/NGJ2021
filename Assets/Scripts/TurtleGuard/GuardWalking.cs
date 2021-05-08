using System.Collections;
using System.Collections.Generic;
using States;
using UnityEngine;

public class GuardWalking : State
{
    private TurtleGuardController actor;
    private float duration = 0.6f;
    private float timer = 0;
    private bool timerComplete = false;
    public GuardWalking(TurtleGuardController actor) : base(actor)
    {
        this.actor = actor;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        Movement();
        RotateTowardsDirection();
        actor.DrainingEnergy();
    }

    public override void OnEnterState()
    {
        base.OnEnterState();
        actor.animator.SetTrigger("isMoving");
        timer = 0;
        actor.canBePickedUp = false;
    }

    public override void OnExitState()
    {
        base.OnExitState();
    }

    public override void Update()
    {
        base.Update();
        
        timerComplete = timer > duration;
        if(timerComplete) return;
        timer += Time.deltaTime;
        if (timer > duration)
            actor.canBePickedUp = true;
    }

    private float timeCount = 0;
    private void RotateTowardsDirection()
    {
        if(actor.controllerVector == Vector3.zero) return;
        
        var lookRotation = Quaternion.LookRotation(actor.controllerVector.normalized);
        timeCount = timeCount + Time.deltaTime;
        var slerpedRot = Quaternion.Slerp(actor.transform.rotation, lookRotation, Time.deltaTime * actor.rotationSpeed);
        actor.transform.rotation = slerpedRot;
    }
    private void Movement()
    {
        
        MovementAnimations();
        var velocity = actor.controllerVector.normalized * actor.GetGuardSpeed();
        var yVelocity = actor.myRigidbody.velocity.y;
        
        actor.myRigidbody.velocity = new Vector3(velocity.x, yVelocity,velocity.z);
    }

    private float transitionToWalk = 0;
    private float transitionToIdle = 0;
    private float transitionDuration = 0.5f;

    void MovementAnimations()
    {
        if (actor.isMoving)
        {
            transitionToIdle = 0;
            var animationLerp = 1;
            transitionToWalk += Time.deltaTime;
            if (transitionToWalk < transitionDuration)
            {
                var percent = transitionToWalk / transitionDuration;
                actor.animator.SetFloat("movement",Mathf.Lerp(0,1,percent));
            }
            else
            {
                actor.animator.SetFloat("movement",1);
            }
        }
        else
        {
            transitionToWalk = 0;
            var animationLerp = 0;
            transitionToIdle += Time.deltaTime;
            if (transitionToIdle < transitionDuration)
            {
                var percent = transitionToIdle / transitionDuration;
                actor.animator.SetFloat("movement",Mathf.Lerp(1,0,percent));
            }
            else
            {
                actor.animator.SetFloat("movement",0);
            }
        }
        
        actor.animator.SetFloat("energyLevel",actor.GetEnergyPercent());
    }
}
