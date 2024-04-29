using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{

  
    private List<ItemShop> shopItemList = new List<ItemShop> ();

    private static ShopManager instance;
    public static ShopManager Instance => instance;

    [SerializeField] private int sizeItemOfShop;
    public int SizeItemOfShop => sizeItemOfShop;

    
    [SerializeField] private List<ItemShop> shopListRandom = new List<ItemShop>();
    public List<ItemShop> ShopItemList => shopItemList;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than 1 instance in your game. Instance has removed");
            return;
        }
        instance = this;
    }




    private void Start()
    {
        LoadItemShop();
    }


    public void LoadItemShop()
    {
        shopItemList.Clear();
        foreach (ItemShop item in shopListRandom)
        {
            int percent = Random.Range(0, 100);
            if (percent <= item.percentRandom)
            {
                shopItemList.Add(item);
            }
        }
        ShopUI.Instance.LoadItemShop();
    }


    private void RealoadItemCallback()
    {
        shopItemList.Clear();
        LoadItemShop();
        
    }


    private void OnEnable()
    {
        LoadShopButton.RealoadItem += RealoadItemCallback;

    }



    private void OnDisable()
    {
        LoadShopButton.RealoadItem -= RealoadItemCallback;
    }

}



[System.Serializable]
public class ItemShop
{
    public string Name;
    public Item Item;
    public int price;
    public int percentRandom;
}