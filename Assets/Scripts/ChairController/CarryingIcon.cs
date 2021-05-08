using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CarryingIcon : MonoBehaviour
{
    public void ScaleAndDisplay(bool isDisplaying)
    {
        if (isDisplaying)
        {
            
            transform.localScale = Vector3.one;
            gameObject.SetActive(true);
            transform.DOScale(Vector3.zero, 0.3f).SetEase(Ease.OutQuint).OnComplete(() =>
            {
                transform.DOScale(Vector3.one * 2f, 0.3f).SetLoops(-1,LoopType.Yoyo);
            });
        }
        else if (!isDisplaying)
        {
            transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutQuint).OnComplete(() =>
            {
                gameObject.SetActive(false);
            });
        }
    }
}
