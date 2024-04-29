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


    public void LoadInforItemInShop(ItemShop itemShop)
    {
        iconItemInShop.sprite = itemShop.Item.iconItem;
        priceItem_TMP.text = $"${itemShop.price}";
    }


    public void ShowInforItemInShop(bool isDisplay)
    {
        iconItemInShop.gameObject.SetActive(isDisplay);
        priceItem_TMP.gameObject.SetActive(isDisplay);  
    }



}

