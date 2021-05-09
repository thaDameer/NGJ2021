using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using States;
using UnityEngine;
using Random = UnityEngine.Random;

public class EggSpawner : MonoBehaviour
{
    public static EggSpawner Instance;
    [SerializeField]private List<EggLogic> eggs = new List<EggLogic>();
    [SerializeField] private List<EggLogic> spawnedEggs = new List<EggLogic>();
    [SerializeField] private List<Turtle> bornTurtles;
    public List<Turtle> BornTurtles => bornTurtles;
    public int minTime, maxTime;
    private float currentTime;
    private float spawnTime;
    private void Start()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);
        
        eggs = GetComponentsInChildren<EggLogic>().ToList();
        spawnTime = currentTime + (Random.Range(minTime, maxTime));
    }

    public void AddHatchedTurtle(Turtle turtle)
    {
        bornTurtles.Add(turtle);
    }
    private void Update()
    {
        if(eggs.Count <= 0) return;
        
        currentTime += Time.deltaTime;
        if (currentTime > spawnTime)
        {
            var randomEggIndex = Random.Range(0, eggs.Count-1);
            eggs[randomEggIndex].SpawnEgg();
            spawnedEggs.Add(eggs[randomEggIndex]);
            eggs.RemoveAt(randomEggIndex);
            currentTime = 0;
            spawnTime = Random.Range(minTime, maxTime);
        }
    }

    public Transform GetRandomEggOrTurtleTransform()
    {
        if (spawnedEggs.Count > 0 && bornTurtles.Count > 0)
        {
            var random = Random.Range(0, 1);
            if (random == 0)
            {
                return GetRandomEggTransform();
            }else if (random == 1)
            {
                return GetRandomTurtleTransform();
            }
        }else if (spawnedEggs.Count > 0 && bornTurtles.Count <= 0)
            return GetRandomEggTransform();
        else if (bornTurtles.Count > 0 && spawnedEggs.Count <= 0)
            return GetRandomTurtleTransform();
        
        
        return null;
        
    }

    private Transform GetRandomEggTransform()
    {
        var randomVal = Random.Range(0, spawnedEggs.Count - 1);
        return spawnedEggs[randomVal].transform;
    }

    private Transform GetRandomTurtleTransform()
    {
        return bornTurtles[Random.Range(0, bornTurtles.Count - 1)].transform;
    }

    public void RemovedBornTurtle(Turtle turtle)
    {
        if(bornTurtles.Count <=0) return;
        for (int i = 0; i < bornTurtles.Count; i++)
        {
            if (spawnedEggs[i] == turtle)
            {
                bornTurtles.RemoveAt(i);
            }
        }
    }
    public void RemovedSpawnedEgg(EggLogic egg)
    {
        if(spawnedEggs.Count<=0) return;

        for (int i = 0; i < spawnedEggs.Count; i++)
        {
            if (spawnedEggs[i] == egg)
            {
                spawnedEggs.RemoveAt(i);
            }
        }
    }
    
}
