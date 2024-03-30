using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileHandler 
{
    string dirFile = "";
    string fileName = "";
    public FileHandler(string dirFile, string fileName)
    {
        this.dirFile = dirFile;
        this.fileName = fileName;
        CreateFileIfFileNotExists();
    }

   
    private void CreateFileIfFileNotExists()
    {
        string path = Path.Combine(dirFile, fileName);
        if (!File.Exists(path))
        {
            File.Create(path);
            Debug.Log("File is created. Path: " + path);
        }
    }


    public GameData ReadData()
    {
        GameData data;
        string path = Path.Combine(dirFile,fileName);
        try
        {
            string dataRead = File.ReadAllText(path);
            data = JsonUtility.FromJson<GameData>(dataRead);
            return data;
        }
        catch (Exception e)
        {
            Debug.LogError(e);
            return null;
        }
    }


    public void WriteData(GameData gameData)
    {
        string path = Path.Combine(dirFile, fileName);
        try
        {
            string json = JsonUtility.ToJson(gameData,true);
            File.WriteAllText(path, json);
        }
        catch (Exception e)
        {
            Debug.LogError(e);
        }
    }
}
