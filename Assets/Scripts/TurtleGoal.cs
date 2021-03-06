using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleGoal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var turtle = GetComponentInParent<Turtle>();
        if (turtle)
        {
            EggSpawner.Instance.RemovedBornTurtle(turtle);
            GameManager.Instance.SavedTurtle();
        }
    }
}
