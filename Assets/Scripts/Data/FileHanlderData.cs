using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class FileHanlderData
{
    string dirPathFile = "";
    string fileName = "";


    public FileHanlderData(string dirFile, string fileName)
    {
        this.dirPathFile = dirFile;
        this.fileName = fileName;
        CreateFileIfFileNotExits();
    }
    

    private void CreateFileIfFileNotExits()
    {
        String pathFile = Path.Combine(dirPathFile, fileName);
        if (!File.Exists(pathFile))
        {
            File.Create(pathFile);
        }
    }


    // LoadGame
    public GameData ReadData()
    {
        GameData data = null;
        string fullPath = Path.Combine(dirPathFile, fileName);
        try
        {
            var jsonData = File.ReadAllText(fullPath);
            data = JsonUtility.FromJson<GameData>(jsonData);    
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
        }
        return data;
    }


    // Save Game
    public void WriteData(GameData data)
    {
        string fullPath = Path.Combine(dirPathFile, fileName);
        try
        {
            string jsonData = JsonUtility.ToJson(data,true);
            File.WriteAllText(fullPath, jsonData);
        }
        catch (Exception ex)
        {
            Debug.LogError(ex.Message);
        }
    }



}
