using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornDamage : MonoBehaviour
{
    public float damage;
    bool colliderBusy = false;
  
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Player" && !colliderBusy)
        {

            colliderBusy = true;
            other.GetComponent<PlayerManager>().GetDamage(damage);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            colliderBusy = false;
        }
    }
}
