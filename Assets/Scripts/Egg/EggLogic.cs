
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using DG.Tweening;
using UnityEngine;

using Vector3 = UnityEngine.Vector3;

public class EggLogic : MonoBehaviour
{
    public enum EggState
    {
        EggInSand,
        EggPopup,
        EggCrack,
        EggHatching,
    }
    
    [SerializeField]private EggState eggState;
    [SerializeField] private float minSpawnTime, maxSpawnTime;
    [SerializeField] private Animator eggAnimator;
    [SerializeField] private Turtle turtlePrefab;
    [SerializeField] private Collider Collider;

    public int eggHealth = 3;
   
    public void SpawnEgg()
    {
        eggState = EggState.EggInSand;
        StartCoroutine(EggPopUp_CO());
    }

    public float GetRandomBetweenMinMax()
    {
        var randomTime = Random.Range(minSpawnTime, maxSpawnTime);
        return randomTime;
    }

    IEnumerator EggPopUp_CO()
    {
        eggState = EggState.EggPopup;
        eggAnimator.SetTrigger("PopUp");
        var randomTime = GetRandomBetweenMinMax();
        yield return new WaitForSeconds(randomTime);
        
        EggHatch();
    }

    public void DealDamage()
    {
        eggHealth -= 1;
    }

    void EggHatch()
    {
        eggState = EggState.EggHatching;
        eggAnimator.SetTrigger("EggHatch");
        var turtleClone = Instantiate(turtlePrefab,transform);
        turtleClone.transform.position = transform.position;
        turtleClone.SpawnTurtle();
        Collider.enabled = false;
        EggSpawner.Instance.RemovedSpawnedEgg(this);
        Destroy(this);
        //spawn turtle
    }
}
