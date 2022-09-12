using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class LoginChecker : MonoBehaviour
{
    private string path = "Assets/Resources/LoginInformation.txt";
    public InputField usernamebox;
    public InputField passwordbox;

    public void Start()
    {
        
    }
    public void Login()
    {
        int i = 0;
        StreamReader reader = new StreamReader(path, true);
        Debug.Log(LogInStatus.LoggedIn);
        for(string line = reader.ReadLine(); line != null || LogInStatus.LoggedIn; line = reader.ReadLine())
        {
            if(line.Contains(usernamebox.text) && line.Contains(passwordbox.text))
            {
                i++;
            }
        }
        LogInStatus.LoggedIn = i > 0;
        Debug.Log(LogInStatus.LoggedIn);
        reader.Close();
    }
}

public static class LogInStatus
{
    public static bool LoggedIn = false;
}