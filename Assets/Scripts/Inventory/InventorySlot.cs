using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;
public class InventorySlot : MonoBehaviour
{
    [SerializeField] private Image iconItem;
    [SerializeField] private Image amountItemContainer;
    [SerializeField] private TextMeshProUGUI amountItem_TMP;
    public static event Action<int> OnClickSelectIndexSlot;
    public int indexSlot { get; set;}

   
    public void OnClickSlot()
    {
        OnClickSelectIndexSlot?.Invoke(indexSlot);
    }
   


    public void ShowInforSlot(bool isDisplay)
    {
        iconItem.gameObject.SetActive(isDisplay);
        amountItemContainer.gameObject.SetActive(isDisplay);
        amountItem_TMP.gameObject.SetActive(isDisplay);
    }
}
