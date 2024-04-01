using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private static Inventory instance;
    public static Inventory Instance => instance;

    [SerializeField] private int inventorySize;
    private int indexInventory;
    public int InventorySize => inventorySize;


    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than 1 instanne in your game!! Instance has been removed");
            return;
        }
        instance = this;
    }



    private void Start()
    {
        InventoryUI.Instance.InitSlot();
    }




    private void GetIndexInventoryCallback(int index)
    {
        indexInventory = index;
        Debug.Log("Click in slot : " + indexInventory);
    }


    private void OnEnable()
    {
        InventorySlot.OnClickSlot += GetIndexInventoryCallback;
    }

    private void OnDisable()
    {
        InventorySlot.OnClickSlot += GetIndexInventoryCallback;
    }
}
