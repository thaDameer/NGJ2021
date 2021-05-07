using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using States;

public class Actor : MonoBehaviour
{
    public State previousState;
    private State PreviousState{get{return previousState;}}
    public State currentState;
    private State CurrentState{get{return currentState;}}
    public Animator animator;

    public virtual void Update()
    {
        currentState.Update();
    }
    public virtual void FixedUpdate()
    {
        currentState.FixedUpdate();
    }


    public void _EnterState(State newState)
    {
        if(currentState == null)
        {
            currentState = newState;
        }
        else
        {
            currentState.OnExitState();
            previousState = currentState;
            currentState = newState;
        }
    }

    IEnumerator StateIEnumerator;
    public void _StateCoroutine(IEnumerator co)
    {
        //store info of this Ienumerator so we can stop it if needed.
        StateIEnumerator = co;
        //start coroutine in the state
        StartCoroutine(co);
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (currentState == null ) return;

        currentState.OnCollisionEnter(collision);
    }



}
