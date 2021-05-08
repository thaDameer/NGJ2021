using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DebugSpeed : MonoBehaviour
{
    [SerializeField]private TMP_Text text;
    private string currentSpeedText = "Current speed: ";
    private void Update()
    {
        var speed = GameManager.Instance.ChairController.CurrentSpeed;
        var speedText = currentSpeedText + speed;;
        text.text = speedText;
    }
}
