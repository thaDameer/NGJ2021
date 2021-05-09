using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullEnemyDetector : MonoBehaviour
{
    public bool canAttack;
    [SerializeField] private Seagull Seagull;
    private void OnTriggerEnter(Collider other)
    {
        var egg = other.GetComponentInParent<EggLogic>();
        if (egg)
        {
            Seagull.AttackEgg(egg);
        }
        var turtle = other.GetComponentInParent<Turtle>();
        if (turtle)
        {
            Seagull.AttackTurtle(turtle);
        }
        canAttack = egg || turtle ? true : false;
        
            
    }

    private void OnTriggerExit(Collider other)
    {
        var egg = other.GetComponentInParent<EggLogic>();
        var turtle = other.GetComponentInParent<Turtle>();
        canAttack = egg || turtle ? false : default;
    }
}
