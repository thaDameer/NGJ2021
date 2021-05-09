using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SeagullSpawner : MonoBehaviour
{
    [SerializeField] private List<SeagullSpawner> Spawners = new List<SeagullSpawner>();
    [SerializeField] private Seagull seagullPrefab;
    [SerializeField] private float minSpawnTime, maxSpawnTime;
    private float timer;
    private float randomTime;
    
    private void Start()
    {
        randomTime = Random.Range(minSpawnTime, maxSpawnTime);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer < randomTime)
        {
            var randomSpawner = Random.Range(0, Spawners.Count - 1);
            var spawn = Spawners[randomSpawner].transform.position;
            var clone = Instantiate(seagullPrefab);
            clone.
        }
    }
}
