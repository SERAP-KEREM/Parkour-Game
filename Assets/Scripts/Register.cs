using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Register : MonoBehaviour
{

    public GameObject Username;
    public GameObject Email;
    public GameObject Password;
    public GameObject ConfirmPassword;
    private string username;
    private string email;
    private string password;
    private string confirmPassword ;
    private string form;
    private bool EmailValid = false;
    private string[] Characters = { "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p","q", "r", "s", "t", "u", "w", "x", "v", "y", "z",
                                  "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P","Q", "R", "S", "T", "U", "W", "X", "V", "Y", "Z",
                                  "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "-", "_"};


    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            if (Username.GetComponent<InputField>().isFocused)
            {
                Email.GetComponent<InputField>().Select();
            }
            if (Email.GetComponent<InputField>().isFocused)
            {
                Password.GetComponent<InputField>().Select();
            }
            if (Password.GetComponent<InputField>().isFocused)
            {
                ConfirmPassword.GetComponent<InputField>().Select();
            }
        }
        if (Input.GetKeyUp(KeyCode.Return))
        {
            if (password != "" && email != "" && password != "" && confirmPassword != "")
            {
                RegisterButton();

            }
        }
        username = Username.GetComponent<InputField>().text;
        email = Email.GetComponent<InputField>().text;
        password = Password.GetComponent<InputField>().text;
        confirmPassword = ConfirmPassword.GetComponent<InputField>().text;

    }
    public void RegisterButton()
    {
        
        bool UN = false;
        bool EM = false;
        bool PW = false;
        bool CPW = false;
        if (username != "")
        {
            if (!System.IO.File.Exists(@"C:\Users\MONSTER\Desktop\UnityProjeler\UygulamaTasarim\Data\Data" + username + ".txt"))
            {
                
                UN = true;
            }
            else
            {
                print("Username Taken.");
                Debug.LogWarning("Username Taken.");
            }
        }
        else
        {
            print("Username Field Empty!");
            Debug.LogWarning("Username Field Empty!");
        }
        if (email != "")
        {
            EmailValidation();
            if (EmailValid)
            {
                if (email.Contains("@"))
                {
                    if (email.Contains("."))
                    {
                        
                        EM = true;
                    }
                    else
                    {
                        print("Email in Incorrect");
                        Debug.LogWarning("Email in Incorrect");
                    }
                }
                else
                {
                    print("Email in Incorrect");
                    Debug.LogWarning("Email in Incorrect");
                }
            }
            else
            {
                print("Email in Incorrect");
                Debug.LogWarning("Email in Incorrect");
            }
        }
        else
        {
            print("Email Field Empty!");
            Debug.LogWarning("Email Field Empty!");
        }
        if (password != "")
        {
            if (password.Length > 5)
            {
                PW = true;

            }
            else
            {
                print("PassWord Must Be atleast 6 Characters long");
                Debug.LogWarning("PassWord Must Be atleast 6 Characters long");

            }
        }
        else
        {
            print("Password Field Empty!");
            Debug.LogWarning("Password Field Empty!");

        }

        if (confirmPassword != "")
        {
            if (confirmPassword == password)
            {
                CPW = true;
            }
            else
            {
                print("Password Don't Match");
                Debug.LogWarning("Password Don't Match");
            }
        }
        else
        {
            print("Confirm Password Field Empty!");
            Debug.LogWarning("Confirm Password Field Empty!");
        }
        if (UN == true && EM == true && PW == true && CPW == true)
        {
            bool Clear = true;
            int i = 1;
            foreach(char c in password)
            {
                if(Clear)
                {
                    password = "";
                    Clear = false;
                }
                i++;
                char Encrypted = (char)(c * i);
                password += Encrypted.ToString();
            }
            form = (username + "\n" + email + "\n" + password);
            System.IO.File.WriteAllText(@"C:\Users\MONSTER\Desktop\UnityProjeler\UygulamaTasarim\Data\Data" + username + ".txt", form);
            //C:\Users\MONSTER\Desktop\UnityProjeler\UygulamaTasarim\Data
            Username.GetComponent<InputField>().text="";
            Email.GetComponent<InputField>().text = "";
            Password.GetComponent<InputField>().text = "";
            ConfirmPassword.GetComponent<InputField>().text = "";
            print("Registration Complete!");

        }
    }
    public void EmailValidation()
    {
        bool SW = false;
        bool EW = false;
        for (int i = 0; i < Characters.Length; i++)
        {
            if (email.StartsWith(Characters[i]))
            {
                SW = true;
            }
        }
        for (int i = 0; i < Characters.Length; i++)
        {
            if (email.EndsWith(Characters[i]))
            {
                EW = true;
            }
        }
        if(SW==true&&EW==true)
        {
            EmailValid = true;
        }
        else
        {
            EmailValid = false;
        }
    }
}
