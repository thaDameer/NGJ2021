using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleGoal : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var turtle = GetComponentInParent<Turtle>();
        if(turtle)
            GameManager.Instance.SavedTurtle();
    }
}
