using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class SlotShopItem : MonoBehaviour
{
    [SerializeField] private Image iconItemInShop;
    [SerializeField] private TextMeshProUGUI priceItem_TMP;
    public int Index { get; set; }
    public ItemShop itemShopLoaded;

    public void LoadInforItemInShop(ItemShop itemShop)
    {
        itemShopLoaded = itemShop;
        iconItemInShop.sprite = itemShop.Item.iconItem;
        priceItem_TMP.text = $"${itemShop.price}";
    }


    public void ShowInforItemInShop(bool isDisplay)
    {
        iconItemInShop.gameObject.SetActive(isDisplay);
        priceItem_TMP.gameObject.SetActive(isDisplay);  
    }

    public void OnSelectedToBuyItem()
    {
        if(MoneyManager.Instance.Money >= itemShopLoaded.price)
        {
            MoneyManager.Instance.Money -= itemShopLoaded.price;
            MoneyUI.Instance.UpdateMoney();
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Not enough money");
        }
    }

}

