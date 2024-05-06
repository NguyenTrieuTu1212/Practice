using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="Level",fileName ="Level_SO")]
public class Level_SO : ScriptableObject
{
    [Header("Requirement Stats for player")]
    public int healthRequirement;
    public int strengthRequirement;
    public int timeRequirement;

    [Header("Reward for payer")]
    public int coinAmount;

    public bool isWinLevel;
}


[System.Serializable]
public class Level
{
    public string nameLevel;
    public Level_SO levelPrebsSO;
}