using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PointAdd : MonoBehaviour, IDataPersistance
{
    [SerializeField] private TextMeshProUGUI amounPoint_TMP;
    private int amountPoint = 0;



    public void LoadGame(GameData gamedata)
    {
        amountPoint = gamedata.pointAmount;
    }

    public void SaveGame(ref GameData gamedata)
    {
        gamedata.pointAmount = amountPoint;
    }


    private void AddPointCallBack(int pointAdd)
    {
        amountPoint += pointAdd;
        amounPoint_TMP.text = $"Point: {amountPoint}";
    }

    private void OnEnable()
    {
        ButtonPoint.OnCLickButtonAddPoint += AddPointCallBack;
    }



    private void OnDisable()
    {
        ButtonPoint.OnCLickButtonAddPoint -= AddPointCallBack;
    }

}
