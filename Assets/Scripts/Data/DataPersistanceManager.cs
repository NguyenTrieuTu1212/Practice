using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class DataPersistanceManager : MonoBehaviour
{
    private static DataPersistanceManager instance;
    public static DataPersistanceManager Instance => instance;
    [SerializeField] private string fileName = "";
    private GameData gameData;
    private List<IDataPersistance> dataPersistances;
    private FileHandler fileHandler;


    private void Awake()
    {
        if(instance != null)
        {
            Debug.Log("More than 1 instance in your game !!!!. Instance has been removed");
            Destroy(gameObject);
            return;
        }
        instance = this;
        fileHandler = new FileHandler(Application.persistentDataPath,fileName);
        DontDestroyOnLoad(gameObject);
    }



    private void Start()
    {
        dataPersistances = FindAllInterfaceInGameObject();
        LoadGame(); 
    }


    private void NewGame()
    {
        gameData = new GameData();
    }



    private void LoadGame()
    {
        gameData = fileHandler.ReadData();
        if(gameData == null) NewGame();
        foreach(IDataPersistance persistance in dataPersistances)
        {
            persistance.LoadGame(gameData);
        }
        Debug.Log("Load data game is" + gameData.point);
    }


    private void SaveGame()
    {
        foreach (IDataPersistance persistance in dataPersistances)
        {
            persistance.SaveGame(ref gameData);
        }

        fileHandler.WriteData(gameData);
        Debug.Log("Save data game is" + gameData.point);
    }


    private void OnApplicationQuit()
    {
        SaveGame();
    }

    private List<IDataPersistance> FindAllInterfaceInGameObject()
    {
        IEnumerable<IDataPersistance> dataPersistances = FindObjectsOfType<MonoBehaviour>().OfType<IDataPersistance>();
        return new List<IDataPersistance>(dataPersistances);
    }


    
}
