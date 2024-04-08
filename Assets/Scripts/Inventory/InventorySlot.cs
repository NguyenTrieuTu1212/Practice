using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image iconItem;
    [SerializeField] private Image amountContainer;
    [SerializeField] private TextMeshProUGUI amountItem_TMP;

    public static event Action<int> InventorySlotClicked;
    public int Index { get; set; }



    public void UpdateSlot()
    {
        iconItem.gameObject.SetActive(false);
        amountContainer.gameObject.SetActive(false);   
    }


    public void SelectedSlot()
    {
        InventorySlotClicked?.Invoke(Index);
    }

}
