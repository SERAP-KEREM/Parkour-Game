using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManagerInGame : MonoBehaviour
{
    public GameObject inGameScreen, pauseScreen;
    public GameObject dataText,dataBoard,winPanel;

    public void PauseButton()
    {
        Time.timeScale = 0;
        inGameScreen.SetActive(false);
        pauseScreen.SetActive(true);
    }

    public void PlayButton()
    {
        Time.timeScale = 1;
        pauseScreen.SetActive(false);
        inGameScreen.SetActive(true);
    }

    public void RePlayButton()
    {
        Time.timeScale = 1;
        
       SceneManager.LoadScene(1);
       DataManager.Instance.gamePuan=0;
       DataManager.Instance.SaveData();
    }
   
    public void HomeButton()
    {
        Time.timeScale = 1;
        DataManager.Instance.SaveData();
        SceneManager.LoadScene(0);
    }
    public void NextButton()
    {
        SceneManager.LoadScene(2);
    }
    public void NextButton2()
    {
        SceneManager.LoadScene(3);
    }
    public void Exit()
    {
        //dataText.SetActive(true);
        winPanel.SetActive(false);
        //DataManager.Instance.LoadData();
    }

    
}
