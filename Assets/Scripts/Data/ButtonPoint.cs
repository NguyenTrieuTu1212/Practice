using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class ButtonPoint : MonoBehaviour
{
    private int pointAmount = 10;
    public static event Action<int> OnCLickButtonAddPoint;


    public void ClickButton()
    {
        OnCLickButtonAddPoint?.Invoke(pointAmount);
    }
}
