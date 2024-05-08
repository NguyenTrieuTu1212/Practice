using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergyText : MonoBehaviour
{
    [SerializeField] private Image iconEnergy;
    [SerializeField] private TextMeshProUGUI amountEnenrgy_TMP;
    [SerializeField] private TextMeshProUGUI amountEnenrgy_BG_TMP;
    public void LoadInfoAmountTextEnergy(int amount)
    {
        amountEnenrgy_TMP.text = $"-{amount}";
        amountEnenrgy_BG_TMP.text = amountEnenrgy_TMP.text;
    }


    public void DestroyTextEnergy()
    {
        Destroy(gameObject);
    }
}
