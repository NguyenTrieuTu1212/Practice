using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(menuName = "Items SO",fileName ="Items SO")]
public class Items_SO : ScriptableObject
{
    public string nameItem;
    public Sprite imageItem;
    public int amountIncreaseEnergy;
}
