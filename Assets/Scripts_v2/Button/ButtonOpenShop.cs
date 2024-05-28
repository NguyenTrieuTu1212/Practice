using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonOpenShop : MonoBehaviour
{
   

    public void OpenAndCloseShop(bool isDisplay)
    {
        AudioManager.Instance.PlaySFX("Press");
        gameObject.SetActive(isDisplay);
    }
    
}
