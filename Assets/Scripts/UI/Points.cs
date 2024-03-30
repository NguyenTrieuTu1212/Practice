using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI point_TMP;
    int pointToAdd = 0;



    private void AddPointCallBackl(int point)
    {
        pointToAdd += point;
        point_TMP.text = $"Point: {pointToAdd}";
    }

    private void OnEnable()
    {
        Button.OnClickButton += AddPointCallBackl;
    }
    

    private void OnDisable()
    {
        Button.OnClickButton -= AddPointCallBackl;
    }

    
}
