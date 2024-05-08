using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvenoryLoadUI : MonoBehaviour
{

    private static InvenoryLoadUI instance;
    public static InvenoryLoadUI Instance => instance;

    [SerializeField] private InventorySlots inventorySlotPref;
    [SerializeField] private Transform Cointainer;
    private List<InventorySlots> listSlotInventory = new List<InventorySlots>();

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than 1 instance in your game!!! Instance has been removed !!!!");
            return;
        }
        instance = this;
    }



    private void Start()
    {
        InitSLot();
    }



    public void LoadInforSlot(Items_SO item, int indexSlot)
    {
        InventorySlots slot = listSlotInventory[indexSlot];
        if (item == null) return;
        slot.ShowImageItem(true);
        slot.LoadItem(item);
    }


    private void InitSLot()
    {
        for(int i = 0; i < InventoryManager.Instance.ListItemInventory.Count; i++)
        {
            InventorySlots slot = Instantiate(inventorySlotPref, Cointainer);
            slot.Index = i;
            slot.ShowImageItem(false);
            listSlotInventory.Add(slot);
        }
    }

}
