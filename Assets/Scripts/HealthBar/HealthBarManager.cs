using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarManager : MonoBehaviour
{
    [SerializeField] private Slider processSlider;
    private float maxTime = 0.25f;

    private void Awake()
    {
        processSlider.value = maxTime;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            processSlider.value += 5f * 0.02f;
        }
        processSlider.value -= Time.deltaTime * 0.2f;
    }

}
