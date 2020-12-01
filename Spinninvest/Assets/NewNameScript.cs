using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewNameScript : MonoBehaviour
{
    public Text playerNameText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetPlayerName()
    {
        if(playerNameText.text == "")
        {
            NameScript.SetUserName("Bob Ross");
        }
        else
        {
            NameScript.SetUserName(playerNameText.text);
        }
        
        

    }
}
