using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private static Inventory instance;
    public static Inventory Instance => instance;
    [SerializeField] private int inventorySize;
    public int InventorySize => inventorySize;
    public int currentIndex;


    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than instance in your game!!! instance has removed");
            return;
        }

        instance = this;
    }



    private void Start()
    {
        InventoryUI.Instance.InitSlot();
    }


    private void GetIndexSlotCallback(int indexSlot)
    {
        currentIndex = indexSlot;
        Debug.Log("Select is: " + currentIndex);
    }

    private void OnEnable()
    {
        InventorySlot.OnClickSelectIndexSlot += GetIndexSlotCallback;
    }

    private void OnDisable()
    {
        InventorySlot.OnClickSelectIndexSlot -= GetIndexSlotCallback;
    }



}
