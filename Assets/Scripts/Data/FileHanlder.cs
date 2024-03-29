using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
public class FileHanlder 
{
    string dirFile = "";
    string nameFile = "";
    public FileHanlder(string dirFile, string nameFile)
    {
        this.dirFile = dirFile;
        this.nameFile = nameFile;
        CreateFileIfNotExists();
    }



    private void CreateFileIfNotExists()
    {
        string path = Path.Combine(dirFile, nameFile);
        if (!File.Exists(path))
        {
            File.Delete(path);
            Debug.Log("File Json is created because file not exists. Path is: " + path);
        }
    }


    public GameData ReadData()
    {
        GameData data = null;
        string path = Path.Combine(dirFile, nameFile);
        try
        {
            string jsonData = File.ReadAllText(path);
            data = JsonUtility.FromJson<GameData>(jsonData);
            return data;
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
            return null;
        }

    }



    public void WriteData(GameData gameData)
    {
        string path = Path.Combine(dirFile, nameFile);
        try
        {
            string jsonData =JsonUtility.ToJson(gameData,true);
            File.WriteAllText(path, jsonData);
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
    }
}
