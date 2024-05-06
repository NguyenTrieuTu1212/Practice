using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    [SerializeField] private Player player;



    [Header("Configue Stats for Player")]
    [SerializeField] private TextMeshProUGUI helthPlayer_TMP;
    [SerializeField] private TextMeshProUGUI energyPlayer_TMP;
    [SerializeField] private TextMeshProUGUI strengthPlayer_TMP;
    [SerializeField] private TextMeshProUGUI coinAmount_TMP;


    private void Update()
    {
        LoadStatsPlayer();
    }


    private void LoadStatsPlayer()
    {
        helthPlayer_TMP.text = $"{player.Stats.health}";
        energyPlayer_TMP.text = $"{player.Stats.energy}";
        strengthPlayer_TMP.text = $"{player.Stats.strength}";
        coinAmount_TMP.text = $"{player.Stats.coin}";
    }




}
