using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private static InventoryUI instance;
    public static InventoryUI Instance => instance;
    
    [SerializeField] private InventorySlot slotPrefabs;
    [SerializeField] private Transform container;
    [SerializeField] private List<InventorySlot> slots;

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


    public void DrawItem(ItemSO item, int index)
    {
        InventorySlot slot = slots[index];
        if(item == null)
        {
            slot.ShowInforSlot(false);

        }
        slot.ShowInforSlot(true);
        slot.UpdateSlot(item);
    }

    public void InitInventory()
    {
        for(int i = 0; i < Inventory.Instance.InventorySize; i++)
        {
            InventorySlot slot = Instantiate(slotPrefabs, container);
            slot.Index = i;
            slots.Add(slot);
            slot.ShowInforSlot(false);
        }
    }
}
