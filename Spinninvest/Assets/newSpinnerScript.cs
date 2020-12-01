using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using DialogueEditor;

public class newSpinnerScript : MonoBehaviour
{
    //game objects
    [Header("Set in Inspector")]
    public GameObject spinner;
    [Header("Set in Inspector")]
    public GameObject ageBar;
    public GameObject ProgressBar;
    AudioSource aSrc;

    //variables
    public float rotationalSpeed = 0;
    float randomRange = 0;
    bool isClicked = false;
    public float totalAngle = 0;
    public float finalAngle = 0;
    public bool finalAngleCalculated = false;
    public bool isRewarded = true;
    public int ageBarValue = 18;

    void Start()
    {
        //sets the age bar to default level
        BarScript ProgressBar = ageBar.GetComponent<BarScript>();
        ProgressBar.SetValue(ageBarValue);

        //sets the audio file to play whne clicked
        this.gameObject.AddComponent<AudioSource>();
        aSrc = this.GetComponent<AudioSource>();
    }
    
    void Update()
    {
        //rotates and slows down wheel
        if (isClicked == true)
        {
        transform.Rotate(0,0, this.rotationalSpeed);       
        rotationalSpeed *= randomRange;
        }


        // stops the wheel
        if(rotationalSpeed <= .01f)
        {
        isClicked = false;
        rotationalSpeed = 0;
        }

        //calculates the last z position of the wheel
        if(rotationalSpeed == 0){
        totalAngle = Mathf.RoundToInt(transform.eulerAngles.z);
        totalAngle = Mathf.Abs(totalAngle);
        }

        //rotates the spinner if it lands on the interavals
        if (totalAngle >= 29.8 && totalAngle <= 30.2 || totalAngle >= 59.8 && totalAngle <= 60.2 || totalAngle > 89.8 && totalAngle < 90.2 || totalAngle >= 119.8 && totalAngle <= 120.2 || totalAngle >= 149.8 && totalAngle <= 150.2 || totalAngle >= 179.8 && totalAngle <= 180.2 || totalAngle >= 209.8 && totalAngle <= 210.2 || totalAngle >= 239.8 && totalAngle <= 240.2 || totalAngle >= 269.8 && totalAngle <= 270.2 || totalAngle >= 299.8 && totalAngle <= 300.2 || totalAngle >= 329.8 && totalAngle <= 330.2 || totalAngle >= 359.8 && totalAngle <= 359.9)
        {
            transform.Rotate (0,0,3);
            totalAngle = Mathf.RoundToInt(transform.rotation.z);          
        }
        //calculates final angle
        if(finalAngleCalculated == false && rotationalSpeed == 0){
            finalAngle = totalAngle;
            finalAngleCalculated = true;
            Debug.Log(finalAngle);
        }

       
    }

    void OnMouseDown()
    {
        //gets some random values and assigns it to variables and increments progress bar by 1
        if(isClicked == false)
        {
        this.rotationalSpeed = RandomNumberSpinSpeed(100, 200);
        IncrementAge();
         this.GetComponent<AudioSource>().Play();
        } 
        randomRange = RandomNumberSlow(.98f, .99f);
        isClicked = true;
        finalAngleCalculated = false;
        isRewarded = false;

    }

    
    //gets number for rate spinner slows down
    public float RandomNumberSlow(float number, float number2)
    {
    float return1 = Random.Range(number, number2);
    return return1;
    
    }
    //gets a random number for number of spins
    public float RandomNumberSpinSpeed(float number, float number2)
    {
    float return1 = Random.Range(number, number2);
    return return1;       
    }

    public void IncrementAge()
    {
        BarScript ProgressBar = ageBar.GetComponent<BarScript>();
        ageBarValue += 1;
        ProgressBar.SetValue(ageBarValue);
    }
}