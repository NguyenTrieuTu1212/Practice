using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Player_Stats",menuName = "Player Stats")]
public class PlayerStats : ScriptableObject
{
    [Header("===== Configue health for player =====")]
    public int health;
    public int maxHealth;
    public int minRangeValueIncreaseHealth;
    public int maxRangeValueIncreaseHealth;


    [Header("===== Configue energy for player =====")]
    public int energy;
    public int maxEnergy;
    public int energyRequirementsPerWorkout;


    [Header("===== Configue strength for player =====")]
    public int strength;
    public int maxStrength;
    public int ValueIncreaseStrength;

    [Header("===== Configue money for player =====")]
    public int coin;
    public void ResetStatsPlayer()
    {
        health = 1;
        maxHealth = 100;
        energy = 100;
        strength = 0;
        energyRequirementsPerWorkout = 5;
        minRangeValueIncreaseHealth = 1;
        maxRangeValueIncreaseHealth = 1;
    }
}
