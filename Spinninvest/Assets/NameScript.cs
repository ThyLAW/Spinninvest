using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NameScript : MonoBehaviour
{
    public string UserName;
    static private NameScript S;

    void Start()
    {
        S = this;
    }

    //sets username

    public static void SetUserName(string userName)
    {
      
        S.UserName = userName;
    }

    //gets username
    public static string GetUserName()
    {
        return S.UserName;
    }
}