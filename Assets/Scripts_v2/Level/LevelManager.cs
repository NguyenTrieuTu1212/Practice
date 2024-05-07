using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instance => instance;


    [SerializeField] private Level[] listLevel;
    public Level[] Levels   
    {
        get { return listLevel; }   
        set { listLevel = value; }  
    }

    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than 1 instance in your game!!! Instace has been removed.");
            return;
        }
        instance = this;
        LoadIndexLevel();
    }



    

    public void LoadIndexLevel()
    {
        UIManager.Instance.LoadStatsRequirement();
    }



}
