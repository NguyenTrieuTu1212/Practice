using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InventoryUI : MonoBehaviour
{
    private static InventoryUI instance;
    public static InventoryUI Instance => instance;


    [SerializeField] private InventorySlot slotPrefabs;
    [SerializeField] private Transform containerSlot;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than 1 instance in your game");
            return;
        }
        instance = this;
    }



    public void InitSlot()
    {
        for(int i = 0; i < Inventory.Instance.InventorySize; i++)
        {
            InventorySlot slot = Instantiate(slotPrefabs, containerSlot);
            slot.indexSlot = i;
            slot.ShowInforSlot(false);
        }
    }
}
