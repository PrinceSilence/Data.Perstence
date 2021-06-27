using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public int highScore;
    public string playerName;

    public static SaveManager instatance;

    private void Start()
    {
        Load();
    }

    private void Awake()
    {
        if(instatance != null)
        {
            Destroy(gameObject);
            return;
        }
        instatance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    [System.Serializable]
    class SaveSystem
    {
        public int highScore;
        public string playerName;
    }

    public void SaveHighScore()
    {
        SaveSystem data = new SaveSystem(); //lets you access the savesystem class from your savemanager class
        data.highScore = highScore;         //sets the save system highscore = the savemanagers highscore
        data.playerName = playerName;

        string json = JsonUtility.ToJson(data); //makes a new string and converts it to a json string

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);//writes the save to a file
    }
 //   public void SavePlayerName()
 //   {
 //       SaveSystem data = new SaveSystem();
 //       data.playerName = playerName;
 //
 //       string json = JsonUtility.ToJson(data);
 //
 //       File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
 //   }
    public void Load()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveSystem data = JsonUtility.FromJson<SaveSystem>(json);

            highScore = data.highScore;
            playerName = data.playerName;
        }
    }
}
