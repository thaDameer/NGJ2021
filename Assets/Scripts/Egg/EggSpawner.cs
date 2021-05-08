using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class EggSpawner : MonoBehaviour
{
    [SerializeField]private List<EggLogic> eggs;
    public int minTime, maxTime;
    private float currentTime;
    private float spawnTime;
    private void Start()
    {
        eggs = GetComponentsInChildren<EggLogic>().ToList();
        spawnTime = currentTime + (Random.Range(minTime, maxTime));
        Debug.Log(eggs.Capacity);
    }

    private void Update()
    {
        if(eggs.Count <= 0) return;
        
        currentTime += Time.deltaTime;
        if (currentTime > spawnTime)
        {
            var randomEggIndex = Random.Range(0, eggs.Count-1);
            eggs[randomEggIndex].SpawnEgg();
            eggs.RemoveAt(randomEggIndex);
            spawnTime = currentTime + Random.Range(minTime, maxTime);
        }
    }
}
