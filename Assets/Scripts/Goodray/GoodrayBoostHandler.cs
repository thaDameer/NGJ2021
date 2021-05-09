using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GoodrayBoostHandler : MonoBehaviour
{
    [SerializeField]private List<GodRayBooster> inactiveBoosters = new List<GodRayBooster>();
    [SerializeField]private List<GodRayBooster> activeBoosters = new List<GodRayBooster>();
    [SerializeField] private float minWait,maxWait;
    private float timer = 0;
    private float spawnTime;
    void Start()
    {
        inactiveBoosters = GetComponentsInChildren<GodRayBooster>().ToList();
        spawnTime = Random.Range(minWait, maxWait);
    }

        
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnTime)
        {
           
            if (inactiveBoosters.Count > 0)
            {
                var randomValue = Random.Range(0, inactiveBoosters.Count - 1);
                inactiveBoosters[randomValue].ActivateGoodRay();
                activeBoosters.Add(inactiveBoosters[randomValue]);
                inactiveBoosters.RemoveAt(randomValue);
                
            }
            spawnTime = Random.Range(minWait, maxWait);
            timer = 0;
            
        }
    }

    public void AddToInactiveBoosters(GodRayBooster godRayBooster)
    {
        for (int i = 0; i < activeBoosters.Count; i++)
        {
            if (activeBoosters[i] == godRayBooster)
            {
                inactiveBoosters.Add(activeBoosters[i]);
                activeBoosters.RemoveAt(i);
                break;
            }   
        }
    }
}
