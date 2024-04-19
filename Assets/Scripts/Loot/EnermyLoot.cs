using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnermyLoot : MonoBehaviour
{
    [SerializeField] private List<ItemDrop> itemDrops = new List<ItemDrop>();
    public List<ItemDrop> listDropRandom { get; set; } = new List<ItemDrop>();


    private void Awake()
    {
        LoadListDropForEnenrmy();
    }


    private void LoadListDropForEnenrmy()
    {
        foreach(ItemDrop item in itemDrops)
        {
            int change = Random.Range(1,100);
            Debug.Log("Change is :" + change);
            if(item.change <= change) listDropRandom.Add(item);
           
        }
    }
}




[System.Serializable]
public class ItemDrop
{
    public string nameItem;
    public int amountItem;
    public Item item;
    public float change;
    public bool isLoot { get; set; }
}