using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class SlotLoot : MonoBehaviour
{
    [SerializeField] private Image spriteItemLoot;
    [SerializeField] private TextMeshProUGUI nameItemLoot_TMP;
    [SerializeField] private TextMeshProUGUI amountItemloot;


    public void LoadInfoItemLoot(ItemDrop itemDrop)
    {
        spriteItemLoot.sprite = itemDrop.item.iconItem;
        nameItemLoot_TMP.text = itemDrop.nameItem;
        amountItemloot.text = $"X {itemDrop.amountItem}";
    }
 
}
