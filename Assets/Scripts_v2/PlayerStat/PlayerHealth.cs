using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private Player player;
    public int currentHealth { get; set; }


    private void Awake()
    {
        player = GetComponent<Player>();
        currentHealth = player.Stats.health;
    }


    public void IncreaseHealth(int amount)
    {
        currentHealth += amount;
        if(currentHealth > player.Stats.maxHealth) currentHealth = player.Stats.maxHealth;
        player.Stats.health = currentHealth;
    }
}
