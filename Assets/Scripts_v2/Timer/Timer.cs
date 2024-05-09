using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private Image panelShop;
    [SerializeField] private Animator animator; 
    [SerializeField] private TextMeshProUGUI timeDisplay_TMP;

    public float remainigTime { get; set; }



    private void Update()
    {
        if (remainigTime < 0) return;
        CheckTimeOut();
        if(!panelShop.IsActive()) CountdownTime();
    }


    private void CountdownTime()
    {
        remainigTime -= Time.deltaTime;
        remainigTime = Mathf.Max(remainigTime, 0f);
        float minutes = Mathf.FloorToInt(remainigTime / 60);
        float seconds = Mathf.FloorToInt(remainigTime % 60);
        timeDisplay_TMP.text = String.Format("{0:00}:{1:00}", minutes, seconds);
    }


    private void CheckTimeOut()
    {
        if (remainigTime <= 10) animator.SetBool("isTimeOut", true);
        else animator.SetBool("isTimeOut", false);
    }

}
