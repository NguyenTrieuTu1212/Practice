using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Threading.Tasks;
using UnityEngine.UI;
public class PlayerEnergy : MonoBehaviour
{
    private Player player;
    [SerializeField] private Image panelAlert;
    [SerializeField] private Animator animatorOfEnergyTMP;

    public int currentEnergy { get; set; }
    private bool canIncrease = true;
    private bool isDisplayAlert = false;

    private void Awake()
    {
        player = GetComponent<Player>();
        currentEnergy = player.Stats.energy;
    }



    private void Update()
    {
        isDisplayAlert = currentEnergy <= 10 ? true : false;
        panelAlert.gameObject.SetActive(isDisplayAlert);
        if (isDisplayAlert) player.GetComponent<Animator>().SetBool("isPractice", false);
        if (currentEnergy <= 20 && canIncrease) StartCoroutine(WaitingIncreaseEnenrgy());
        if (currentEnergy <= 10) animatorOfEnergyTMP.SetBool("isFlicker", true);
        else animatorOfEnergyTMP.SetBool("isFlicker", false);
    }

    public void DegreeEnergy(int amount)
    {
        player.Stats.energy = Math.Max(currentEnergy-=amount,0);
        currentEnergy = player.Stats.energy;
        EnergyText energyText = TextManager.Instance.TakeText(amount);
        Debug.Log("Current Energy is: " + currentEnergy);
    }

    IEnumerator WaitingIncreaseEnenrgy()
    {
        canIncrease = false;
        currentEnergy++;
        if(currentEnergy > player.Stats.maxEnergy) currentEnergy = player.Stats.maxEnergy;  
        player.Stats.energy = currentEnergy;    
        yield return new WaitForSeconds(2f);
        canIncrease = true;
    }

    


    private void ResetEnergyCallback()
    {
        currentEnergy = player.Stats.maxEnergy;
    }


    private void OnEnable()
    {
        ButonNext.OnClickNextLevel += ResetEnergyCallback;
        ButtonReplay.OnClickReplayLevel += ResetEnergyCallback;

    }


    private void OnDisable()
    {
        ButonNext.OnClickNextLevel -= ResetEnergyCallback;
        ButtonReplay.OnClickReplayLevel -= ResetEnergyCallback;
    }
}
