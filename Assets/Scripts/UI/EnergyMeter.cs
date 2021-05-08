using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyMeter : MonoBehaviour
{
    [SerializeField] private Image energyMeter;
    private RectTransform rectTransform;
    [SerializeField] private Color restingColor, attackingColor, drainingColor;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void UpdateEnergyGraphics(float percent,Transform characterTransform)
    {
        Vector2 myPositionOnScreen = Camera.main.WorldToScreenPoint (characterTransform.transform.position);
        float scaleFactor = UIManager.Instance.GameplayCanvas.scaleFactor;
        Vector2 finalPosition = new Vector2 (myPositionOnScreen.x / scaleFactor , myPositionOnScreen.y+250 / scaleFactor);
        rectTransform.anchoredPosition = finalPosition;
        energyMeter.fillAmount = percent;
    }

}
