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

    public Items_SO CopyItem()
    {
        Items_SO instance = Instantiate(this);
        return instance;
    }

    public virtual bool UseItem()
    {
        if(Player.Instance.Stats.energy >= Player.Instance.Stats.maxEnergy) return false;
        Player.Instance.Stats.energy += amountIncreaseEnergy;
        return true;
    }

    public virtual void EquipItem()
    {

    }

    public virtual void RemoveItem()
    {

    }
}
