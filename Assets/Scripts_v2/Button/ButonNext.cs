using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ButonNext : MonoBehaviour
{
    public static event Action OnClickNextLevel;

    public void OnClickButtonNextLevel()
    {
        AudioManager.Instance.PlaySFX("Press");
        UIManager.Instance.NextLevel();
        OnClickNextLevel?.Invoke();
    }
}
