using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManagerMenuScene : MonoBehaviour
{
    public GameObject dataBoard;
    public GameObject highScoreTable;
    public void PlayButton()
    {
        SceneManager.LoadScene(1);
        DataManager.Instance.Gamepuan = 0;
    }
    public void DataBoardButton()
    {
        DataManager.Instance.LoadData();
        dataBoard.transform.GetChild(1).GetComponent<Text>().text = PlayerPrefs.GetString("username") + " : "   + DataManager.Instance.gamePuan.ToString();
        dataBoard.transform.GetChild(2).GetComponent<Text>().text = PlayerPrefs.GetString("nameText") + " : " + DataManager.Instance.totalGamePuan.ToString();
        dataBoard.SetActive(true);
    }
    //public void DataBoardButton()
    //{
    //    //Debug.Log(PlayerPrefs.GetString("username"));
    //    //DataManager.Instance.LoadData();

    //    //highScoreTable.transform.GetChild(1).GetComponent<Text>().text = DataManager.Instance.nameText.ToString();
    //    highScoreTable.transform.GetChild(2).GetComponent<Text>().text = PlayerPrefs.GetString("gamePuan");
    //    highScoreTable.transform.GetChild(3).GetComponent<Text>().text = PlayerPrefs.GetString("username");
    //    highScoreTable.SetActive(true);
    //}

    public void XButton()
    {
        dataBoard.SetActive(false);
    }
    public void OkeyButton()
    {
        highScoreTable.SetActive(false);

    }
}

