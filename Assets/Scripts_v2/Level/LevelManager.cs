using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    private static LevelManager instance;
    public static LevelManager Instace => instance;



    [SerializeField] private Timer timer;
    [SerializeField] private TextMeshProUGUI healthRequirement_TMP;
    [SerializeField] private TextMeshProUGUI strengthRequirement_TMP;

    [SerializeField] private Level[] listLevel;


    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than 1 instance in your game!!! Instace has been removed.");
            return;
        }
        instance = this;
    }



    private void Start()
    {
        LoadIndexLevel(1);
    }



    public void LoadIndexLevel(int levelIndex)
    {
        if (levelIndex >= listLevel.Length) return;
        timer.remainigTime = listLevel[levelIndex].levelPrebsSO.timeRequirement;
        strengthRequirement_TMP.text = listLevel[levelIndex].levelPrebsSO.strengthRequirement.ToString();
        healthRequirement_TMP.text = listLevel[levelIndex].levelPrebsSO.healthRequirement.ToString();

    }



}
