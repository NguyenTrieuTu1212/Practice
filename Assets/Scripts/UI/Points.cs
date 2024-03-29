using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Points : MonoBehaviour, IDataPersistance
{

    [SerializeField] private TextMeshProUGUI point_TMP;
    int pointToAdd = 0;


    public void LoadGame(GameData data)
    {
        pointToAdd = data.point;
    }

    public void SaveGame(ref GameData data)
    {
        data.point = pointToAdd;
    }

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
