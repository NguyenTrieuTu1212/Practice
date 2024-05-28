using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistanceManager : MonoBehaviour
{
    private static DataPersistanceManager instance;
    public static DataPersistanceManager Instance => instance;

    private List<IDataPersistance> dataPersistances = new List<IDataPersistance>();
    private GameData gameData;

    [SerializeField] private string fileName = "";
    private FileHanlderData fileHanlderData;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than 1 instance in your game !!! ");
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
        fileHanlderData = new FileHanlderData(Application.persistentDataPath, fileName);    
        
    }


    private void Start()
    {
        dataPersistances = FindAllIDataPersistanceInGame();
        LoadGame();
    }

    public void NewGame()
    {
        gameData = new GameData();
    }


    public void LoadGame()
    {
        gameData = fileHanlderData.ReadData();
        if (gameData == null) NewGame();
        foreach (IDataPersistance persistance in dataPersistances)
        {
            persistance.LoadGame(gameData);
        }
        Debug.Log("Game data load is: " + gameData.pointAmount);
    }


    public void SaveGame()
    {
        foreach(IDataPersistance persistance in dataPersistances)
        {
            persistance.SaveGame(ref gameData);
        }
        fileHanlderData.WriteData(gameData);
        Debug.Log("Game data saved is : " + gameData.pointAmount);
    }


    private void OnApplicationQuit()
    {
        SaveGame();
    }



    private List<IDataPersistance> FindAllIDataPersistanceInGame()
    {
        IEnumerable<IDataPersistance> dataPersistances = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();
        return new List<IDataPersistance>(dataPersistances);
    }


}
