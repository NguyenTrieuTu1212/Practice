using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public void OnClickPlayAudio()
    {
        AudioManager.Instance.PlaySFX("Bip");
    }
}
