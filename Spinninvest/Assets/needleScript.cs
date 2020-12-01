using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class needleScript : MonoBehaviour
{
    public GameObject spinner;
    public GameObject needle;
    bool isRotated = false;
    float rotationalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gets spinner script's rotational speed
        rotationalSpeed = GameObject.Find("Spinner").GetComponent<newSpinnerScript>().rotationalSpeed;

        //rotates the needle if it hits the intervals 
        if (isRotated == false && spinner.transform.eulerAngles.z > 0 && spinner.transform.eulerAngles.z < 1 || spinner.transform.eulerAngles.z > 29 && spinner.transform.eulerAngles.z < 31 || spinner.transform.eulerAngles.z > 59 && spinner.transform.eulerAngles.z < 61 || spinner.transform.eulerAngles.z > 89 && spinner.transform.eulerAngles.z < 91
            || spinner.transform.eulerAngles.z > 119 && spinner.transform.eulerAngles.z < 121 || spinner.transform.eulerAngles.z > 149 && spinner.transform.eulerAngles.z < 151 || spinner.transform.eulerAngles.z > 179 && spinner.transform.eulerAngles.z < 181
            || spinner.transform.eulerAngles.z > 209 && spinner.transform.eulerAngles.z < 211 || spinner.transform.eulerAngles.z > 239 && spinner.transform.eulerAngles.z < 241 || spinner.transform.eulerAngles.z > 269 && spinner.transform.eulerAngles.z < 271
            || spinner.transform.eulerAngles.z > 299 && spinner.transform.eulerAngles.z < 301 || spinner.transform.eulerAngles.z > 329 && spinner.transform.eulerAngles.z < 331 || spinner.transform.eulerAngles.z > 359 && spinner.transform.eulerAngles.z <= 360)
        {
            needle.transform.rotation = Quaternion.Euler(0, 0, 0);
            isRotated = true;
        }

        //rotates needle back to original position
        if (isRotated == true && spinner.transform.eulerAngles.z >= 1 && spinner.transform.eulerAngles.z <=29 || spinner.transform.eulerAngles.z >= 31 && spinner.transform.eulerAngles.z <= 59 || spinner.transform.eulerAngles.z >= 61 && spinner.transform.eulerAngles.z <= 89 || spinner.transform.eulerAngles.z >= 91 && spinner.transform.eulerAngles.z <= 119
            || spinner.transform.eulerAngles.z >= 121 && spinner.transform.eulerAngles.z <= 149 || spinner.transform.eulerAngles.z >= 151 && spinner.transform.eulerAngles.z <= 179 || spinner.transform.eulerAngles.z >= 181 && spinner.transform.eulerAngles.z <= 209
            || spinner.transform.eulerAngles.z >= 211 && spinner.transform.eulerAngles.z <= 239 || spinner.transform.eulerAngles.z >= 241 && spinner.transform.eulerAngles.z <= 269 || spinner.transform.eulerAngles.z >= 271 && spinner.transform.eulerAngles.z <= 299
            || spinner.transform.eulerAngles.z >= 301 && spinner.transform.eulerAngles.z <= 329 || spinner.transform.eulerAngles.z >= 331 && spinner.transform.eulerAngles.z <= 359)
        {
            needle.transform.rotation = Quaternion.Euler(0, 0, -45);
            isRotated = false;
        }

        //sets needle to original position once spinner stops moving
        if (rotationalSpeed == 0)
        {

            isRotated = false;
            needle.transform.rotation = Quaternion.Euler(0, 0, -45);
        }

       
    }
}
