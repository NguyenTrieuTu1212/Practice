using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public enum TypeSkin {
    Ninja,
    GirlCave
}


public class TypeChangeSkin : MonoBehaviour
{
    public TypeSkin typeSkin;
    public static Action<TypeSkin> OnSelectSkin;



    public void ClickButtonSelectSkin()
    {
        OnSelectSkin?.Invoke(typeSkin);
    }
}
