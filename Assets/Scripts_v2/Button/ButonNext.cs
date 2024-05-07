using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButonNext : MonoBehaviour
{
    public void OnClickButtonNextLevel()
    {
        UIManager.Instance.NextLevel();
    }
}
