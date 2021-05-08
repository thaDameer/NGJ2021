using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodRayBooster : MonoBehaviour
{
    [SerializeField] private Collider boostCollider;
    [SerializeField] private Animator goodRayAnimator;
    private bool isTriggered = false;

    private void Start()
    {
        goodRayAnimator.SetTrigger("Appear");
    }

    public void ActiveGoodRay()
    {
        
    }

    public void TurnOffGoodRay()
    {
        
    }

    public void PlayBoostEffect()
    {
        goodRayAnimator.SetTrigger("Boost");
        isTriggered = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        var chair = other.GetComponentInParent<ChairController>();
        if (chair && !isTriggered)
        {
            chair.GetBoost();
            PlayBoostEffect();
        }
    }
}
