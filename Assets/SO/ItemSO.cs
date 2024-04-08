using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(menuName = "Item in Inventory",fileName ="Item")]
public class ItemSO : ScriptableObject
{

    public Sprite iconItem;
    public string amountItem;

}
