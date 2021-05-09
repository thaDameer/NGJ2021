using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Seagull : MonoBehaviour
{
    [SerializeField] private Rigidbody myRigidbody;

    private bool hasTarget;
    private Transform target;
    private Vector3 direction;
    private float moveSpeed = 2f;
    private void Update()
    {
        if (target)
        {
            direction = (transform.position - target.transform.position).normalized;
            myRigidbody.velocity = direction * moveSpeed;
        }
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
    public void GetClosestTurtleOrEgg()
    {
        
    }
}
