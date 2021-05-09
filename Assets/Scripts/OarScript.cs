using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OarScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var seagull = other.GetComponent<Seagull>();
        if (seagull)
        {
            Debug.Log("hit bird");
        }
    }
}
