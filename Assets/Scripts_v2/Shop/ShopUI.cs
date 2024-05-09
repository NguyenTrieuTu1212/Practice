using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private Transform Container;
    [SerializeField] private SlotShopItem slotShopItem;


    private static ShopUI instance;
    public static ShopUI Instance => instance;



    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than 1 instance in youre game. Instance has been removed !!!!");
            return;
        }
        instance = this;
    }



    public void LoadItemShop()
    {
        DestroySlotShopItem();
        foreach(ItemShop item in ShopManager.Instance.ShopItemList)
        {
            SlotShopItem slot = Instantiate(slotShopItem, Container);
            slot.LoadInforItemInShop(item);
        }
    }


    private void DestroySlotShopItem()
    {
        foreach(Transform child in Container.transform)
        {
            Destroy(child.gameObject);
        }
    }
    
}
