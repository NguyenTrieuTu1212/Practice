using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : MonoBehaviour
{

    int point = 0;




    private void AddPointCallBack(int addIndex)
    {
        point += addIndex;
        Debug.Log(point);
    }

    private void OnEnable()
    {
        ButtonCallBack.OnClickToAddPoint += AddPointCallBack;
    }


    private void OnDisable()
    {
        ButtonCallBack.OnClickToAddPoint -= AddPointCallBack;
    }
}
