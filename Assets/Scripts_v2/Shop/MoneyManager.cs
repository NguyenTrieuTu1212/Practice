using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    [SerializeField] private int money;
    public int Money   // property
    {
        get { return money; }
        set { money = value; }
    }

    private static MoneyManager instance;
    public static MoneyManager Instance => instance;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }
}
