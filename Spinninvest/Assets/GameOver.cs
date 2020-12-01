using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameOver : MonoBehaviour
{
    public GameObject Spinner;
    private int age;
    public TextMeshProUGUI textName;
    bool below0 = false;

    void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        if (NameScript.GetUserName() == null)
        {
            textName.text = "Bob Ross";
        }
        else { 
        textName.text = NameScript.GetUserName();
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        age = GameObject.Find("Spinner").GetComponent<newSpinnerScript>().ageBarValue;
        if(age > 60)
        {
            SceneManager.LoadScene("sceneGameOver");
        }
        below0 = GameObject.Find("Spinner").GetComponent<rewardPlayer>().below0;
        if (below0 == true)
        {
            SceneManager.LoadScene("sceneBankruptcy");
        }

    }
}
