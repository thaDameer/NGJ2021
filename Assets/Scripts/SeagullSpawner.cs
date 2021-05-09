using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class SeagullSpawner : MonoBehaviour
{
    [SerializeField] private List<Transform> spawnTransforms = new List<Transform>();
    [SerializeField] private Seagull seagullPrefab;
    [SerializeField] private float minSpawnTime, maxSpawnTime;
    private float timer = 0;
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
            var randomSpawner = Random.Range(0, spawnTransforms.Count - 1);
            var spawnPos = spawnTransforms[randomSpawner].transform.position;
            var clone = Instantiate(seagullPrefab);
            clone.transform.position = spawnPos;
            timer = 0;
            //clone.
        }
    }
}

interface ITurtle
{
    
}
