using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LoadShopButton : MonoBehaviour
{
    public static event Action RealoadItem;


    public void OnClickButtonLoad()
    {
        RealoadItem?.Invoke();
    }
}
