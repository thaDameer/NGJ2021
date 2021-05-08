using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpawner : MonoBehaviour
{
    private EggLogic[] eggs;

    private void Start()
    {
        eggs = GetComponentsInChildren<EggLogic>();
    }
}
