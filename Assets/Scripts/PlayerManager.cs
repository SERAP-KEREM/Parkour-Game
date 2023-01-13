using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;



public class PlayerManager : MonoBehaviour
{
    public float health, bulletSpeed, lifeTime = 3f;

    bool dead = false;
    

    Transform muzzle;

    public Transform bullet, floatingText,bloodParticle;

    public Slider slider;

    bool mouseIsNotOverUI;

    public GameObject LosePanel;




    // Start is called before the first frame update
    void Start()
    {
       
        muzzle = transform.GetChild(1);
        slider.maxValue = health;
        slider.value = health;
    }

    // Update is called once per frame
    void Update()
    {
        mouseIsNotOverUI= EventSystem.current.currentSelectedGameObject == null;
        
        if (Input.GetMouseButtonDown(0) && mouseIsNotOverUI)
        {

            ShootBullet();
        }
    }
    public void GetDamage(float damage)
    {

        Instantiate(floatingText, transform.position, Quaternion.identity).GetComponent<TextMesh>().text = damage.ToString();
       
        if ((health - damage) >= 0)
        {
           // Destroy(transform.GetChild().gameObject);
            //Destroy(Instantiate(bloodParticle, transform.position, Quaternion.identity), 3f);

            health -= damage;  
        }
        else
        {
            health = 0;
        }
        slider.value = health;
        AmIDead();

    }
    void AmIDead()
    {
       
        if (health <= 0)
        {

            Destroy(Instantiate(bloodParticle, transform.position, Quaternion.identity), 3f);
            dead = true;
            //Destroy(gameObject);
            LosePanel.SetActive(true);
        }
    }

    void ShootBullet()
    {
        Transform tempBullet;
        tempBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed);
        Destroy(tempBullet.gameObject, lifeTime);
  
    }
  

}
