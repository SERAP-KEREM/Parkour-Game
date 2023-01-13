using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            DataManager.Instance.Gamepuan+=10;
            Destroy(this.gameObject);
        }
    }
}
