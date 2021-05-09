using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using States;
using UnityEngine;


public class Seagull : MonoBehaviour
{
    [SerializeField] private Rigidbody myRigidbody;
    [SerializeField] private Animator animator;
    private bool hasTarget;
    private Transform target;
    private Vector3 direction;
    [SerializeField]private float moveSpeed = 2f;

    private float distanceToTarget;
    private bool targetInRange;
    [SerializeField] private float targetRadius = 3;
    private Coroutine attackRoutine;
    private void FixedUpdate()
    {
        if (target && !targetInRange)
        {
            distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
            direction = (target.transform.position-transform.position).normalized;
            direction.x = 0;
            myRigidbody.velocity = direction * moveSpeed;
            var lookRot = Quaternion.LookRotation(direction.normalized);
            lookRot.x = 0;
            lookRot.z = 0;
            transform.rotation = lookRot;
            bool isAttacking = targetRadius > distanceToTarget;
            animator.SetBool("isAttacking",isAttacking);
            if (targetRadius > distanceToTarget)
            {
                targetInRange = true;
                animator.SetBool("isAttacking",targetInRange);
                attackRoutine = StartCoroutine(AttackRoutine_CO());
            }
        }
    }

    IEnumerator AttackRoutine_CO()
    {
       
        EggLogic egg = target.GetComponentInParent<EggLogic>();
        if (egg)
        {
            while (egg.eggHealth > 0)
            {
                animator.SetTrigger("attack");
                egg.DealDamage();
                yield return new WaitForSeconds(1f);
            }
        }

        Turtle turtle = target.gameObject.GetComponentInParent<Turtle>();
        if (turtle)
        {
            while (turtle.turtleHealth > 0)
            {
                direction = (turtle.transform.position - transform.position).normalized;
                var lookRot = Quaternion.LookRotation(turtle.transform.position);
                lookRot.x = 0;
                lookRot.z = 0;
                transform.rotation = Quaternion.Slerp(transform.rotation,lookRot,0.2f*Time.fixedDeltaTime);
                yield return new WaitForSeconds(1f);
                animator.SetTrigger("attack");
            }
            Debug.Log("attack turtle");
        }else
        {
            target = null;
            LookForEggsTurtle();
        }
        LookForEggsTurtle();
    }

    public void LookForEggsTurtle()
    {
        target = EggSpawner.Instance.GetRandomEggOrTurtleTransform();
        

        if (!target)
            StartCoroutine(WaitAndLookForFood());
    }

    IEnumerator WaitAndLookForFood()
    {
        yield return new WaitForSeconds(0.5f);
        LookForEggsTurtle();
    }

    public void DamageSeagull(Vector3 impact)
    {
        if(attackRoutine!=null)
            StopCoroutine(attackRoutine);
        direction = (impact - transform.position).normalized;
        myRigidbody.AddForce(direction*8,ForceMode.Impulse);
        target = null;
        Destroy(this,2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
