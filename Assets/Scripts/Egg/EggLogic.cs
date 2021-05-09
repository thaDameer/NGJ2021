
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

    public int eggHealth = 3;
    [SerializeField] private GameObject sandIcon;


    [SerializeField] private GameObject egg;
    public void SpawnEgg()
    {
        eggState = EggState.EggInSand;
        
        egg.gameObject.SetActive(false);
        sandIcon.gameObject.SetActive(true);
        sandIcon.transform.localScale = Vector3.zero;
        sandIcon.gameObject.SetActive(true);
        sandIcon.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutQuint);
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
        egg.gameObject.SetActive(true);
        eggAnimator.SetTrigger("PopUp");
        var randomTime = GetRandomBetweenMinMax();
        yield return new WaitForSeconds(randomTime);
        StartCoroutine(EggHatch_CO());
    }

    public void GetDamage()
    {
        eggHealth -= 1;
    }

    IEnumerator EggHatch_CO()
    {
        eggState = EggState.EggHatching;
        eggAnimator.SetTrigger("EggHatch");
        yield return new WaitForSeconds(0.5f);
        var turtleClone = Instantiate(turtlePrefab,transform);
        turtleClone.transform.position = transform.position;
        turtleClone.SpawnTurtle();
        Destroy(this);
        //spawn turtle
    }
}
