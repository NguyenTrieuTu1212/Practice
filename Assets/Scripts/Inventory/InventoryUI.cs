using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private static InventoryUI instance;
    public static InventoryUI Instance => instance;

    [SerializeField] private InventorySlot slotPrefabs;
    [SerializeField] private Transform container;
    

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than 1 instance in your game !!! Instance has been removed");
            Destroy(this);
            return;
        }
        instance = this;
    }


    public void InitInventory()
    {
        for(int i = 0; i < Inventory.Instance.InventorySize; i++)
        {
            InventorySlot slot = Instantiate(slotPrefabs, container);
            slot.Index = i;
            slot.UpdateSlot();
        }
    }
}
