using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private static Inventory instance;
    public static Inventory Instance => instance;


    [SerializeField] private int inventorySize;
    [SerializeField] private ItemSO item;
    public int InventorySize => inventorySize;
    public int currentIndex = 0;


    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than 1 instance in your game !!! Instance had removed");
            return;
        }
        instance = this;
    }


    private void Start()
    {
        InventoryUI.Instance.InitInventory();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            AddItem();
        }
    }


    private void AddItem()
    {
        InventoryUI.Instance.DrawItem(item, 0);
    }

    private void OnClickedSlotCallback(int index)
    {
        currentIndex = index;
        Debug.Log("Index Slot seleted :" + currentIndex);
    }


    private void OnEnable()
    {
        InventorySlot.InventorySlotClicked += OnClickedSlotCallback;
    }


    private void OnDisable()
    {
        InventorySlot.InventorySlotClicked -= OnClickedSlotCallback;
    }

}
