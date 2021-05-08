using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodRayBooster : MonoBehaviour
{
    [SerializeField] private Collider boostCollider;
    [SerializeField] private Animator goodRayAnimator;
    private bool boostConsumed = false;
    [SerializeField] private AudioSource AudioSource;
    [SerializeField] private AudioClip appearClip, disappearClip, boostClip;
    [SerializeField] private float activeTime = 8;
    public bool godRayActive;
    private GoodrayBoostHandler boostHandler;
    private void Start()
    {
        boostHandler = GetComponentInParent<GoodrayBoostHandler>();
    }

    public void ActivateGoodRay()
    {
        if(appearClip && AudioSource)
            AudioSource.clip = boostClip;
        boostConsumed = false;
        godRayActive = true;
        gameObject.SetActive(true);
        goodRayAnimator.SetTrigger("Appear");
        
    }

    // IEnumerator ActiveTimer_CO()
    // {
    //     yield return new WaitForSeconds(activeTime);
    //     TurnOffGoodRay();
    // }
    // public void TurnOffGoodRay()
    // {
    //     boostConsumed = false;
    //     godRayActive = false;
    //     if(disappearClip && AudioSource)
    //         AudioSource.clip = boostClip;
    // }

    public void PlayBoostEffect()
    {
        goodRayAnimator.SetTrigger("Boost");
        if(boostClip && AudioSource)
            AudioSource.clip = boostClip;
        godRayActive = false;
        boostConsumed = true;
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!godRayActive) return;
        var chair = other.GetComponentInParent<ChairController>();
        if (chair && !boostConsumed)
        {
            boostHandler.AddToInactiveBoosters(this);
            chair.GetBoost();
            PlayBoostEffect();
        }
    }
}
