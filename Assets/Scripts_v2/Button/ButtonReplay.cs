using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ButtonReplay : MonoBehaviour
{



    public static event Action OnClickReplayLevel;
    public void OnClickReplayGame()
    {
        AudioManager.Instance.PlaySFX("Press");
        UIManager.Instance.ReplayGame();
        OnClickReplayLevel?.Invoke();    
    }
}
