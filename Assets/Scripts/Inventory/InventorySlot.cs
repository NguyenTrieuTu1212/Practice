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




    public void UpdateSlot(ItemSO item)
    {
        iconItem.sprite = item.iconItem;
        amountItem_TMP.text = item.amountItem;
    }



    public void ShowInforSlot(bool isDisplay)
    {
        iconItem.gameObject.SetActive(isDisplay);
        amountContainer.gameObject.SetActive(isDisplay);   
    }


    public void SelectedSlot()
    {
        InventorySlotClicked?.Invoke(Index);
    }

}
