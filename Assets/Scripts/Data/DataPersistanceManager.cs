using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistanceManager : MonoBehaviour
{
    private static DataPersistanceManager instance;
    public static DataPersistanceManager Instance => instance;


    [SerializeField] private string nameFile = "";

    private List<IDataPersistance> dataPersistances = new List<IDataPersistance>();
    private GameData gameData;
    private FileHanlder fileHanlder;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("More than 1 instance in your game !!! Instance have been deleted");
            Destroy(gameObject);
            return;
        }
        instance = this;
        fileHanlder = new FileHanlder(Application.persistentDataPath,nameFile);
        DontDestroyOnLoad(gameObject);
    }




    private void Start()
    {
        dataPersistances = FindAllDataInObject();
        LoadGame();
    }

    private void NewGame()
    {
        gameData = new GameData();
    }



    private void LoadGame()
    {
        gameData = fileHanlder.ReadData();
        if(gameData == null)
        {
            NewGame();
        }
        foreach(IDataPersistance persistance in dataPersistances)
        {
            persistance.LoadGame(gameData);
        }
        Debug.Log("Load game: " + gameData.point);
    }


    private void SaveGame()
    {
        foreach (IDataPersistance persistance in dataPersistances)
        {
            persistance.SaveGame(ref gameData);
        }
        fileHanlder.WriteData(gameData);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }



    private List<IDataPersistance> FindAllDataInObject()
    {
        IEnumerable<IDataPersistance> listDataPersistances = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();
        return new List<IDataPersistance>(listDataPersistances);

    }


    
}
