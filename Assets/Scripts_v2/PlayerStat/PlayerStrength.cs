using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerStrength : MonoBehaviour
{
    private Player player;
    private PlayerStamina playerStamina;

    private void Awake()
    {
        playerStamina = GetComponent<PlayerStamina>();
        player = GetComponent<Player>();
    }


    public void AddStrength(int amount)
    {
        player.Stats.strength += amount;
        if(player.Stats.strength > player.Stats.maxStrength) player.Stats.strength = player.Stats.maxStrength;
        if(player.Stats.strength % 10 == 0)
        {
            player.Stats.minRangeValueIncreaseHealth++;
            player.Stats.maxRangeValueIncreaseHealth++;
            player.Stats.energyRequirementsPerWorkout--;
            if(player.Stats.energyRequirementsPerWorkout < 0) player.Stats.energyRequirementsPerWorkout = 1;
        }
    
    }
}
