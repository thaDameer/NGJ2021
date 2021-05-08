using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoodRayBooster : MonoBehaviour
{
    [SerializeField] private Collider boostCollider;
    [SerializeField] private Animator goodRayAnimator;
    private bool isTriggered = false;
    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private AudioClip appearClip, disappearClip, boostClip;

    private void Start()
    {
        goodRayAnimator.SetTrigger("Appear");
    }

    public void ActiveGoodRay()
    {
        if(appearClip && AudioSource)
            AudioSource.clip = boostClip;
    }

    public void TurnOffGoodRay()
    {
        if(disappearClip && AudioSource)
            AudioSource.clip = boostClip;
    }

    public void PlayBoostEffect()
    {
        goodRayAnimator.SetTrigger("Boost");
        if(boostClip && AudioSource)
            AudioSource.clip = boostClip;
        
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
