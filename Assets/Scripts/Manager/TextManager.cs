using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextManager : MonoBehaviour
{
    private static TextManager instance;
    public static TextManager Instance => instance;

    [SerializeField] private EnergyText energyPrefabs;
    [SerializeField] private Transform Holder;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than 1 instance in your game!!! Instance has been removed");
            Destroy(this);
            return;
        }
        instance = this;
    }


    public EnergyText TakeText(int amount)
    {
        EnergyText energyText = Instantiate(energyPrefabs, Holder);
        energyPrefabs.LoadInfoAmountTextEnergy(amount);
        energyPrefabs.gameObject.SetActive(true);
        return energyText;
    }
}
