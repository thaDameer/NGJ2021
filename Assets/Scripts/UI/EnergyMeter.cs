using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using States;
using UnityEngine;
using UnityEngine.UI;

public class EnergyMeter : MonoBehaviour
{
    [SerializeField] private Image energyMeter;
    private RectTransform rectTransform;
    [SerializeField] private Color restingColor, attackingColor, drainingColor;
    private Color currentColor;
    private bool isDraining;
    private bool isResting;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    
    public void UpdateEnergyDrain(float percent,Transform characterTransform)
    {
        if (!isDraining)
        {
            energyMeter.DOColor(drainingColor, 0.3f);
            
            isResting = false;
            isDraining = true;
        }
        
        energyMeter.fillAmount = percent;
        //FocusAtCharacter(characterTransform);
    }

    public void UpdateRestingMeter(float percent, Transform characterTransform)
    {
        if (!isResting)
        {
            energyMeter.DOColor(restingColor, 0.3f);
            isDraining = false;
            isResting = true;
        }

        energyMeter.fillAmount = percent;
        //FocusAtCharacter(characterTransform);
    }

    void FocusAtCharacter(Transform characterTransform)
    {
        Vector2 myPositionOnScreen = Camera.main.WorldToScreenPoint (characterTransform.transform.position);
        float scaleFactor = UIManager.Instance.GameplayCanvas.scaleFactor;
        Vector2 finalPosition = new Vector2 (myPositionOnScreen.x / scaleFactor , myPositionOnScreen.y+250 / scaleFactor);
        rectTransform.anchoredPosition = finalPosition;
    }

}
