using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Button : MonoBehaviour
{
    [SerializeField] private int addPoint;
    public static event Action<int> OnClickButton;



    public void ClickButton()
    {
        OnClickButton?.Invoke(addPoint);
    }
}
