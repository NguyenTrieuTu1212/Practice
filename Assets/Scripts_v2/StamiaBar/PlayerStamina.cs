using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using System;
using Random = UnityEngine.Random;


public class PlayerStamina : MonoBehaviour
{
    [SerializeField] private Slider staminaBarPlayer;
    [SerializeField] private float offset;
    [SerializeField] private float maxTimeRequireToChangedColor;
    [SerializeField] private List<Image> nodeList = new List<Image>();


    private Player player;
    private PlayerEnergy playerEnergy;
    private PlayerHealth playerHealth;
    private PlayerStrength playerStrength;
    private Animator animatorPlayer;

    public float speedRunProcessStaminaBar { get; set; }
    private float initValueStaminaBar = 0.25f;
    private bool canPressed = true;
    private int indexNode = 0;
    float timeRequireToChangedColor = 0;




  

    private void Start()
    {
        player = GetComponent<Player>();
        playerEnergy = GetComponent<PlayerEnergy>();
        playerHealth = GetComponent<PlayerHealth>();
        playerStrength = GetComponent<PlayerStrength>();
        animatorPlayer = GetComponent<Animator>();
        staminaBarPlayer.value = initValueStaminaBar;
    }

    private void Update()
    {
        HandleScreenTouch();
        ProcessStaminaBar();
    }


    private void HandleScreenTouch()
    {
        if(staminaBarPlayer.value < 0.25f) animatorPlayer.SetBool("isPractice", false);
        if ((Input.touchCount > 0) && canPressed && playerEnergy.currentEnergy > 10)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                staminaBarPlayer.value += speedRunProcessStaminaBar * 0.02f;
                PlayAnimation();
            }
        }
    }



    private void ProcessStaminaBar()
    {
        speedRunProcessStaminaBar = (staminaBarPlayer.value > 0.75f) ? 3f : 8f;
        if (staminaBarPlayer.value >= 1f)
        {
            if (indexNode < nodeList.Count) ProcessNode();
            if (indexNode >= nodeList.Count)
            {
                playerStrength.AddStrength(player.Stats.ValueIncreaseStrength);

                playerHealth.IncreaseHealth(Random.Range(player.Stats.minRangeValueIncreaseHealth,
                    player.Stats.maxRangeValueIncreaseHealth));

                StartCoroutine(WaitingResetStaminaBar());
            }
        }
        staminaBarPlayer.value -= Time.deltaTime * 0.3f;
        /*if (Input.GetKeyDown(KeyCode.Q) && canPressed && playerEnergy.currentEnergy > 10)
        {
            staminaBarPlayer.value += speedRunProcessStaminaBar * 0.02f;
            animatorPlayer.SetBool("isPractice", true);
            
        }*/


        /*if ((Input.touchCount > 0) && canPressed && playerEnergy.currentEnergy > 10)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                staminaBarPlayer.value += speedRunProcessStaminaBar * 0.02f;
                PlayAnimation();
            }
        }*/



    }




    private void ProcessNode()
    {
        timeRequireToChangedColor += Time.timeScale;
        if (timeRequireToChangedColor >= maxTimeRequireToChangedColor)
        {
            ChangeColorNode(indexNode);
            staminaBarPlayer.value -= offset;
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
        playerEnergy.DegreeEnergy(player.Stats.energyRequirementsPerWorkout);
        await Task.Delay(100);
        AudioManager.Instance.PlaySFX("Bip");
    }


    IEnumerator WaitingResetStaminaBar()
    {
        canPressed = false;
        indexNode = 0;
        while (staminaBarPlayer.value >0f)
        {
            staminaBarPlayer.value -= 0.5f * Time.deltaTime;
            yield return null;
        }
        foreach (var node in nodeList) node.color = Color.red;
        yield return new WaitForSeconds(0.5f);
        canPressed = true;
    }


    private IEnumerator PlayAnimationSmoothly()
    {
        animatorPlayer.SetBool("isPractice", true);
        yield return new WaitForSeconds(0.5f);
    }

    private void PlayAnimation()
    {
        StartCoroutine(PlayAnimationSmoothly());
    }



    /*private async void PlayAnimation()
    {
        animatorPlayer.SetBool("isPractice", true);
        await Task.Delay(500);
        animatorPlayer.SetBool("isPractice", false);
    }
*/

}
