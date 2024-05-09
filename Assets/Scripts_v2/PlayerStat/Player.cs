using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private static Player instance;
    public static Player Instance => instance;
    
    [SerializeField] private PlayerStats stats;
    public PlayerStats Stats => stats;

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than 1 instance in your game !!!! Instance has been removed");
            return;
        }
        instance = this;
    }
   

    private void OnApplicationQuit()
    {
        stats.ResetStatsPlayer();
    }
}
