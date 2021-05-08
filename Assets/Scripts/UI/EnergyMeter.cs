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
    private bool isAttacking;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    
    public void UpdateEnergyDrain(float percent,Transform characterTransform)
    {
        if (!isDraining && !isAttacking)
        {
            energyMeter.DOColor(drainingColor, 0.3f);
            
            isResting = false;
            isDraining = true;
        }
        if(!isAttacking)
            energyMeter.fillAmount = percent;
        else
        {
            timer += Time.deltaTime;
            if (timer > attackDuration)
                isAttacking = false;
            energyMeter.fillAmount = percent;
        }
        //FocusAtCharacter(characterTransform);
    }

    private float timer;
    private float attackDuration = 0.5f;
    public void UpdateAttackDrain(float percent)
    {
        if (!isAttacking)
        {
            energyMeter.DOColor(attackingColor, 0.3f);
            isResting = false;
            isDraining = false;
            isAttacking = true;
            timer = 0;
        }

        
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
