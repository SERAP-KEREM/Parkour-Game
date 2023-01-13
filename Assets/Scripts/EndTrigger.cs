using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndTrigger : MonoBehaviour
{
    public GameObject WinPanel;
    private void OnTriggerEnter2D(Collider2D other)
    {
  
        if (other.tag == "Player" )
        {
            DataManager.Instance.SaveData();
            WinPanel.SetActive(true);
        } 
    }   
}
