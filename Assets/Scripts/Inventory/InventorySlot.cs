using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image iconItem;
    [SerializeField] private Image amountContainer;
    [SerializeField] private TextMeshProUGUI amountItem;

    public int indexSlot { get; set; }
    public static event Action<int> OnClickSlot;
    


    public void ShowInforSlot(bool isDisplay)
    {
        iconItem.gameObject.SetActive(isDisplay);
        amountContainer.gameObject.SetActive(isDisplay);
    }

    public void OnClickSlotInventory()
    {
        OnClickSlot?.Invoke(indexSlot);
    }

}
