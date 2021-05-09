using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using DG.Tweening;
using States;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private Canvas endScreen;

    [SerializeField]private  TMP_Text winText;
    [SerializeField] private EnergyMeter guardEnergyMeter;
    [SerializeField] private Canvas gameplayCanvas;
    [SerializeField] private TMP_Text bornTurtleCounter;
    [SerializeField] private TMP_Text savedTurtlesCounter;
    private string bornTurtles = "Hatched turtles: ";
    private string savedTurtles = "Saved turtles: ";
    public Canvas GameplayCanvas => gameplayCanvas;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

    }

    private void Start()
    {
        bornTurtleCounter.text = bornTurtles + 0;
        savedTurtlesCounter.text = "";
    }
    
    public void UpdateHatchedCounter()
    {
        var message = bornTurtles + GameManager.Instance.GetAmountOfBornTurtles();
        bornTurtleCounter.transform.localScale = Vector3.one * 0.5f;
        bornTurtleCounter.rectTransform.DOScale(Vector3.one, 0.2f).SetEase(Ease.InCubic);
        bornTurtleCounter.text = message;
    }

    public void UpdateSavedTurtles()
    {
        savedTurtlesCounter.transform.localScale = Vector3.zero;
        savedTurtlesCounter.text = savedTurtles + GameManager.Instance.savedTurtles;
        savedTurtlesCounter.transform.DOScale(Vector3.one, 0.4f);
        
    }

    public void ActivateDeathScreen()
    {
        winText.text = "GAME OVER";
        endScreen.gameObject.SetActive(true);
    }
    public void ActivateWinScreen()
    {
        winText.text = "You saved "+GameManager.Instance.savedTurtles+"!!";
        endScreen.gameObject.SetActive(true);
    }
    public void UpdateGuardDrainingMeter(float percent, Transform characterTransform)
    {
        guardEnergyMeter.UpdateEnergyDrain(percent,characterTransform);
    }

    public void UpdateRestingMeter(float percent, Transform characterTransform)
    {
        guardEnergyMeter.UpdateRestingMeter(percent,characterTransform);
    }

    public void UpdateAttackMeter(float percent)
    {
        guardEnergyMeter.UpdateAttackDrain(percent);
    }
}
