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




}
