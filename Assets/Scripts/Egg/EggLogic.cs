
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
    
    private EggState eggState;
    [SerializeField] private float minSpawnTime, maxSpawnTime;
    [SerializeField] private Animator eggAnimator;

    #region EggInSand

    [SerializeField] private GameObject sandIcon;

    #endregion
    private void Start()
    {
        eggState = EggState.EggInSand;
        sandIcon.gameObject.SetActive(false);
        StartCoroutine(EggInSand_CO());
    }

    public float GetRandomBetweenMinMax()
    {
        var randomTime = Random.Range(minSpawnTime, maxSpawnTime);
        return randomTime;
    }
    IEnumerator EggInSand_CO()
    {
        sandIcon.transform.localScale = Vector3.zero;
        sandIcon.transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutBounce);
        yield return new WaitForSeconds(GetRandomBetweenMinMax());

    }
}
