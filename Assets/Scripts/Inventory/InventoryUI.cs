using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private static InventoryUI instance;
    public static InventoryUI Instance => instance;

    [SerializeField] private Transform Container;
    [SerializeField] private InventorySlot inventorySlotPrefabs;
    
    private List<InventorySlot> inventorySlots = new List<InventorySlot>();

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than instance in game !!! Instance removed");
            Destroy(this);
            return;
        }
        instance = this;

    }


    public void InitSlot()
    {
        for(int i = 0; i < Inventory.Instance.InventorySize; i++)
        {
            InventorySlot slot = Instantiate(inventorySlotPrefabs, Container);
            slot.indexSlot = i;
            slot.ShowInforSlot(false);
            inventorySlots.Add(slot);
        }
    }

}
