using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonReroll : MonoBehaviour
{
    public void OnClickToReroll()
    {
        if(Player.Instance.Stats.coin >= 1)
        {
            AudioManager.Instance.PlaySFX("Press");
            ShopManager.Instance.LoadItemShop();
            Player.Instance.Stats.coin -= 1;
        }
        else
        {
            AudioManager.Instance.PlaySFX("NotEnough");
        }
    }
}
