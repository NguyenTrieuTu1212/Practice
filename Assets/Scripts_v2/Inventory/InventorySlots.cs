using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class InventorySlots : MonoBehaviour
{
    [SerializeField] private Image iconItem;
    [SerializeField] private GameObject buttonUse;
    
    public int Index { get; set; }

    public static Action<int> OnClickThisSlot;

    public void LoadItem(Items_SO item)
    {
        iconItem.sprite = item.imageItem;
    }



    public void ShowImageItem(bool isDisplay)
    {
        iconItem.gameObject.SetActive(isDisplay);
    }



    public void OnClickSlot()
    {
        OnClickThisSlot?.Invoke(Index);
    }
}
