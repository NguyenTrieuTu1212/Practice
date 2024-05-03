using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using System;

public class HealthBarManager : MonoBehaviour
{
    [SerializeField] private Slider processSlider;
    [SerializeField][Range(0.01f, 0.5f)] private float offset;
    [SerializeField][Range(1,10f)] private float maxTimeRequireToChangedColor;
    
    [SerializeField] private List<Image> nodeList = new List<Image>();
    private float maxTime = 0.25f;
    private float speedRunProcess = 5f;
    private bool canPressed = true;
    private int indexNode = 0;
    float timeRequireToChangedColor = 0;
    

    private void Awake()
    {
        processSlider.value = maxTime;
    }

    private void Update()
    {
        ProcessBar();
    }


    private void ProcessBar()
    {
        if (Input.GetKeyDown(KeyCode.Q) && canPressed) processSlider.value += speedRunProcess * 0.02f;
        if (processSlider.value > 0.75f) speedRunProcess = 3f;
        if (processSlider.value >= 1f && indexNode < nodeList.Count) Process();
        else if (indexNode >= nodeList.Count) StartCoroutine(WaitingResetSliderBar());
        processSlider.value -= Time.deltaTime * 0.3f;
    }




    private void Process()
    {
        timeRequireToChangedColor += Time.timeScale;
        if (timeRequireToChangedColor >= maxTimeRequireToChangedColor)
        {
            ChangeColorNode(indexNode);
            processSlider.value -= offset;
            timeRequireToChangedColor = 0;
        }
        indexNode++;
    }

    private async void ChangeColorNode(int index)
    {
        await ChangeColorWithSound(index);
    }

    private async Task ChangeColorWithSound(int index)
    {
        nodeList[index].color = Color.green;
        await Task.Delay(100); 
        AudioManager.Instance.PlaySFX("Bip"); 
    }


    IEnumerator WaitingResetSliderBar()
    {
        canPressed = false;
        indexNode = 0;
        while (processSlider.value >0f)
        {
            processSlider.value -= 0.5f * Time.deltaTime;
            yield return null;
        }
        foreach (var node in nodeList) node.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        speedRunProcess = 5f;
        canPressed = true;
    }

   
    
}
