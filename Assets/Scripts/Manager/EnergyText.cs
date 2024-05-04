using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnergyText : MonoBehaviour
{
    [SerializeField] private Image iconEnergy;
    [SerializeField] private TextMeshProUGUI amountEnenrgy_TMP;

    public void LoadInfoAmountTextEnergy(int amount)
    {
        amountEnenrgy_TMP.text = amount.ToString();
    }


    public void DestroyTextEnergy()
    {
        Destroy(gameObject);
    }
}
