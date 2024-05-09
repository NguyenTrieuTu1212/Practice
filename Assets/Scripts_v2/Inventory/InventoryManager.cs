using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{


    [SerializeField] private List<Items_SO> listItemInventory;
    public List<Items_SO> ListItemInventory
    {
        get { return listItemInventory; }
        set { listItemInventory = value; }
    }
    private static InventoryManager instance;
    public static InventoryManager Instance => instance;


    public int currentIndex { get; set; }

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than 1 insance in your game !!!! Instance has been removed");
            return;
        }
        instance = this;
    }

    private void Start()
    {
        for(int i=0;i<listItemInventory.Count;i++)
        {
            InvenoryLoadUI.Instance.LoadInforSlot(listItemInventory[i], i);
        }
    }




    public void AddItemInFreeSlot(Items_SO item)
    {
        for (int i = 0; i < listItemInventory.Count; i++)
        {
            if (ListItemInventory[i] != null) continue;
            ListItemInventory[i] = item.CopyItem();
            InvenoryLoadUI.Instance.LoadInforSlot(listItemInventory[i],i);
            return;
        }
    }

    public bool IsFullInventory()
    {
        for(int i = 0; i < listItemInventory.Count; i++)
        {
            if (listItemInventory[i] == null) return false;
        }
        return true;
    }

    public void UseItem()
    {
        if(listItemInventory[currentIndex] == null) return;
        if (listItemInventory[currentIndex].UseItem()){
            listItemInventory[currentIndex] = null;
            InvenoryLoadUI.Instance.LoadInforSlot(null, currentIndex);
        }
    }

    private void GetIndexSlotCallback(int indexSlot)
    {
        currentIndex = indexSlot;
        Debug.Log("Current slot click is: " + currentIndex);
    }


    private void OnEnable()
    {
        InventorySlots.OnClickThisSlot += GetIndexSlotCallback;
    }
    private void OnDisable()
    {
        InventorySlots.OnClickThisSlot += GetIndexSlotCallback;
    }

}
