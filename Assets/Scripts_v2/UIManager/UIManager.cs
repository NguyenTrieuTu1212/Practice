using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance => instance;


    [SerializeField] private Player player;



    [Header("Configue Stats for Player")]
    [SerializeField] private TextMeshProUGUI helthPlayer_TMP;
    [SerializeField] private TextMeshProUGUI energyPlayer_TMP;
    [SerializeField] private TextMeshProUGUI strengthPlayer_TMP;
    [SerializeField] private TextMeshProUGUI coinAmount_TMP;



    [SerializeField] private Timer timer;
    [SerializeField] private TextMeshProUGUI healthRequirement_TMP;
    [SerializeField] private TextMeshProUGUI strengthRequirement_TMP;




    [Header("Configue Check Task for player")]
    [SerializeField] private Image iconCheckmarkHealth;
    [SerializeField] private Image iconCheckmarkStrength;
    [SerializeField] private Sprite iconCheckmarkComplete;
    [SerializeField] private Sprite iconCheckmarkNotComplete;

    [Header("Configue panel win")]
    [SerializeField] private Image panelWin;
    [SerializeField] private TextMeshProUGUI coinReward_TMP;

    private int levelIndex;
    private int coinReward = 0;
  
    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than 1 instance in your game !!! Instance has been removed !!!!");
            return;
        }
        instance = this;
    }


    private void Start()
    {
        levelIndex = 0;
        panelWin.gameObject.SetActive(false);
    }

    private void Update()
    {
        LoadStatsPlayer();
        CheckCompleteTask();
    }


    private void LoadStatsPlayer()
    {
        helthPlayer_TMP.text = $"{player.Stats.health}";
        energyPlayer_TMP.text = $"{player.Stats.energy}";
        strengthPlayer_TMP.text = $"{player.Stats.strength}";
        coinAmount_TMP.text = $"{player.Stats.coin}";
    }



    public void LoadStatsRequirement()
    {
        timer.remainigTime = LevelManager.Instance.Levels[levelIndex].levelPrebsSO.timeRequirement;
        healthRequirement_TMP.text = LevelManager.Instance.Levels[levelIndex].levelPrebsSO.healthRequirement.ToString();
        strengthRequirement_TMP.text = LevelManager.Instance.Levels[levelIndex].levelPrebsSO.strengthRequirement.ToString();
    }


    private void CheckCompleteTask()
    {
        iconCheckmarkHealth.sprite = player.Stats.health >= LevelManager.Instance.Levels[levelIndex].levelPrebsSO.healthRequirement
                                     ? iconCheckmarkComplete
                                     : iconCheckmarkNotComplete;

        iconCheckmarkStrength.sprite = player.Stats.strength >= LevelManager.Instance.Levels[levelIndex].levelPrebsSO.strengthRequirement
                                    ? iconCheckmarkComplete
                                    : iconCheckmarkNotComplete;

        if (player.Stats.health >= LevelManager.Instance.Levels[levelIndex].levelPrebsSO.healthRequirement
            && player.Stats.strength >= LevelManager.Instance.Levels[levelIndex].levelPrebsSO.strengthRequirement
            && timer.remainigTime > 0)
        {
            if (panelWin.IsActive()) return;
            DisplayPanelWin();
        }
    }




    private void DisplayPanelWin()
    {
        panelWin.gameObject.SetActive(true);
        coinReward = Random.Range(10, 50);
        coinReward_TMP.text = coinReward.ToString();
    }




    public void NextLevel()
    {
        if (levelIndex >= LevelManager.Instance.Levels.Length) return;
        levelIndex++;
        player.Stats.ResetStatsPlayer();
        player.Stats.coin += coinReward;
        panelWin.gameObject.SetActive(false);
        LoadStatsRequirement();
    }




   

}
