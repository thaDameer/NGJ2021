using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpCollider : MonoBehaviour
{
    public bool turtleGuardInZone;
    
    
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.GetComponentInParent<TurtleGuardController>())
        {
            turtleGuardInZone = true;
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        var guard = other.GetComponentInParent<TurtleGuardController>();
        if (guard)
        {
            
            turtleGuardInZone = false;
        }
    }
}
