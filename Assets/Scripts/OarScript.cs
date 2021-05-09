using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OarScript : MonoBehaviour
{
    [SerializeField] private Transform castPos;

    private Coroutine attackRoutine;
    public void OverlapAttack()
    {
        timer = 0;
        if(attackRoutine!=null)
            StopCoroutine(attackRoutine);
        attackRoutine = StartCoroutine(AttackRoutine());
    }

    private float timer = 0;
    private float duration = 0.4f;
    IEnumerator AttackRoutine()
    {
        while (timer < duration)
        {
            timer += Time.deltaTime;
            Collider[] hits = Physics.OverlapSphere(castPos.transform.position, 1.5f);
            foreach (var collider in hits)
            {
               
                Seagull seagull = collider.GetComponentInParent<Seagull>();
                if (seagull)
                {
                    seagull.DamageSeagull(castPos.transform.position);
                    Debug.Log("booo");
                }
                yield return new WaitForEndOfFrame();
            }
        }
        
    }
}
