using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ButtonCallBack : MonoBehaviour
{
    [SerializeField] private int addIndex = 1;

    public static event Action<int> OnClickToAddPoint;


    public void OnClickAddPoint()
    {
        OnClickToAddPoint?.Invoke(addIndex);
    }
}
