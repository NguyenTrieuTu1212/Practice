using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class MoneyUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI moneyAmount_TMP;
    private static MoneyUI instance;
    public static MoneyUI Instance => instance;


    private void Awake()
    {
        if (instance != null) return;
        instance = this;
    }


    private void Start()
    {
        UpdateMoney();
    }


    public void UpdateMoney()
    {
        moneyAmount_TMP.text = $"Money: {MoneyManager.Instance.Money}";
    }

}
