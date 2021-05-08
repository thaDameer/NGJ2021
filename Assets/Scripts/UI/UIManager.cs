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

    public void UpdateGuardEnergyMeter(float percent, Transform characterTransform)
    {
        guardEnergyMeter.UpdateEnergyGraphics(percent,characterTransform);
    }
}
