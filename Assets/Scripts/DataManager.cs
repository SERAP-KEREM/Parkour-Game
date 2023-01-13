using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TigerForge;

using UnityEngine.SceneManagement;//


public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public int gamePuan;
    public int totalGamePuan = 0;
    public string nameText;
 

    EasyFileSave myFile;

    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
            StartProcess();
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    public int Gamepuan
    {
        get
        {
            return gamePuan;
        }

        set
        {
            gamePuan = value;
            GameObject.Find("GamePuanText").GetComponent<Text>().text = "Score : " + gamePuan.ToString();

        }
    }
    public string NameText
    {
        get
        {
            return nameText;
        }

        set
        {
            nameText = value;
            GameObject.Find("NameText").GetComponent<Text>().text =nameText;

        }
    }
    void StartProcess()
    {
        myFile = new EasyFileSave();
        LoadData();
    }

    public void SaveData()
    {

        if (gamePuan >= totalGamePuan)
        {
            totalGamePuan = gamePuan;
            nameText = PlayerPrefs.GetString("username");
            PlayerPrefs.SetInt("gamePuan", gamePuan);
            PlayerPrefs.SetString("nameText", NameText);
            //  PlayerPrefs.SetString("username", username);
        }

        myFile.Add("totalGamePuan", totalGamePuan);
        myFile.Add("gamePuan", totalGamePuan);
        myFile.Add("nameText", nameText);
        myFile.Save();
        
    }
    public void LoadData()
    {

        if (myFile.Load())
        {
            totalGamePuan = myFile.GetInt("totalGamePuan");

        }
    }
}
