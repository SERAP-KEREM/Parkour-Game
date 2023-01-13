using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Login : MonoBehaviour
{
    public GameObject Username;
    public GameObject Password;
    private string username;
    private string password;
    private string[] Lines;
    private string DecryptedPassword;
   

    public static Login Instance;
    void Awake()
    {

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            if (Username.GetComponent<InputField>().isFocused)
            {
                Password.GetComponent<InputField>().Select();
            }
        }
        if (Input.GetKeyUp(KeyCode.Return))
        {
            if (password != "" && password != "")
            {
                LoginButton();

            }
        }
        username = Username.GetComponent<InputField>().text;
        password = Password.GetComponent<InputField>().text;
      

      
    }
    public void LoginButton()
    {
       // Debug.Log(username);
        PlayerPrefs.SetString("username",username);
        bool UN = false;
        bool PW = false;
        if (username != "")
        {
            if (System.IO.File.Exists(@"C:\Users\MONSTER\Desktop\UnityProjeler\UygulamaTasarim\Data\Data" + username + ".txt"))
            {
                UN = true;
                Lines = System.IO.File.ReadAllLines(@"C:\Users\MONSTER\Desktop\UnityProjeler\UygulamaTasarim\Data\Data" + username + ".txt");
            }
            else
            {
                print("Username Invalid");
            }
        }
        else
        {
            print("Username Field Empty");
        }
        if (password != "")
        {
            if (System.IO.File.Exists(@"C:\Users\MONSTER\Desktop\UnityProjeler\UygulamaTasarim\Data\Data" + username + ".txt"))
            {
                int i = 1;
                foreach (char c in Lines[2])
                {
                    i++;
                    char Decrypted = (char)(c / i);
                    DecryptedPassword += Decrypted.ToString();
                }
                if (password == DecryptedPassword)
                {
                    PW = true;
                }
                else
                {
                    print("Password Is Invalid");

                }
            }
            else
            {
                print("Password Is Invalid");

            }

        }
        else
        {
            print("Password Field Empty");
        }
        if (UN == true && PW == true)
        {
            Username.GetComponent<InputField>().text = "";
            Password.GetComponent<InputField>().text = "";
            print("Login Sucessful");
            SceneManager.LoadScene(0);
        }
    }
}
