using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Player_Stats",menuName = "Player Stats")]
public class PlayerStats : ScriptableObject
{
    public int health;
    public int maxHealth;
    public int energy;
    public int maxEnergy;
    public int strength;
    public int maxStrength;
    
}
