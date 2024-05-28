using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class SlotShopItem : MonoBehaviour
{
    [SerializeField] private GameObject panelStatsItemShop;
    [SerializeField] private Image iconItemInShop;
    [SerializeField] private TextMeshProUGUI priceItem_TMP;
    [SerializeField] private TextMeshProUGUI energyIncrease_TMP;
    public int Index { get; set; }
    public ItemShop itemShopLoaded;

    public void LoadInforItemInShop(ItemShop itemShop)
    {
        itemShopLoaded = itemShop;
        iconItemInShop.sprite = itemShop.Item.imageItem;
        priceItem_TMP.text = $"{itemShop.price}";
        energyIncrease_TMP.text = itemShop.Item.amountIncreaseEnergy.ToString();
    }


    public void ShowInforItemInShop(bool isDisplay)
    {
        panelStatsItemShop.gameObject.SetActive(isDisplay);
    }

    public void OnSelectedToBuyItem()
    {
        if(Player.Instance.Stats.coin >= itemShopLoaded.price && !InventoryManager.Instance.IsFullInventory())
        {
            InventoryManager.Instance.AddItemInFreeSlot(itemShopLoaded.Item);
            Player.Instance.Stats.coin -= itemShopLoaded.price;
            Destroy(gameObject);
        }
        else
        {
            AudioManager.Instance.PlaySFX("NotEnough");
            Debug.Log("Not enough money");
        }
    }

}

