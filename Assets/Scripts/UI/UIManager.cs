using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using States;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    [SerializeField] private EnergyMeter guardEnergyMeter;
    [SerializeField] private Canvas gameplayCanvas;
    public Canvas GameplayCanvas => gameplayCanvas;
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(this);

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
