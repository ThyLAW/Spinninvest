using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class WheelController : MonoBehaviour
{
        [Header("Set in Inspector")]
        public GameObject spinner;
        public TextMeshProUGUI textSpins;
        public TextMeshProUGUI textBalance;
        public TextMeshProUGUI textCost;
        public TextMeshProUGUI textRedColorCost;
        public TextMeshProUGUI textBlueColorCost;
        public TextMeshProUGUI textGreenColorCost;
        public TextMeshProUGUI textGoldColorCost;

        [SerializeField]
        public float balance = 1000;
        public float costAmount = 100;
        float rotationalSpeed = 0;
        bool isClicked = false;
        bool isRewarded = true;
        bool finalAngleCalculated = false;
        float randomRange = 0;
        float finalAngle = 0;
        float totalAngle = 0;
        float totalSpins = 0;
        int redSection = -100;
        int blueSection = 0;
        int greenSection = 100;
        int goldSection = 500;


        

    // Start is called before the first frame update
    void Start()
    {
        //sets starter texts
        textBalance.text = "Balance: " + balance;
        textCost.text = "Cost: " + costAmount;
        textRedColorCost.text = "Red: " + redSection;
        textBlueColorCost.text = "Blue: " + blueSection;
        textGreenColorCost.text = "Green: " + greenSection;
        textGoldColorCost.text = "Gold: " + goldSection;

    }

    // Update is called once per frame
    void Update()
    {

        //slows down the wheel
       if(isClicked == true){
           transform.Rotate(0,0, this.rotationalSpeed);       
        rotationalSpeed *= randomRange;
        }
    
        //stops the wheel
        if(rotationalSpeed <= .01f){
            isClicked = false;
            rotationalSpeed = 0;
        }
        
        //gets the last angle after rotated
        if(rotationalSpeed == 0){
        totalAngle = Mathf.RoundToInt(transform.eulerAngles.z);
        totalAngle = Mathf.Abs(totalAngle);
        }
        
        //checks if it lands on the line and moves it, then calcualtes final angle
        if (totalAngle > 0 && totalAngle <= 0.2 || totalAngle >= 29.8 && totalAngle <= 30.2 || totalAngle >= 59.8 && totalAngle <= 60.2 || totalAngle > 89.8 && totalAngle < 90.2 || totalAngle >= 119.8 && totalAngle <= 120.2 || totalAngle >= 149.8 && totalAngle <= 150.2 || totalAngle >= 179.8 && totalAngle <= 180.2 || totalAngle >= 209.8 && totalAngle <= 210.2 || totalAngle >= 239.8 && totalAngle <= 240.2 || totalAngle >= 269.8 && totalAngle <= 270.2 || totalAngle >= 299.8 && totalAngle <= 300.2 || totalAngle >= 329.8 && totalAngle <= 330.2 || totalAngle >= 359.8 && totalAngle <= 360)
        {
            transform.Rotate (0,0,6);
            totalAngle = Mathf.RoundToInt(transform.rotation.z);          
        }
        if(finalAngleCalculated == false && rotationalSpeed == 0){
            finalAngle = totalAngle;
            finalAngleCalculated = true;
        }

        // rewards the player for the spin
        if(rotationalSpeed == 0 && isRewarded == false && finalAngleCalculated == true)
        {
            balance = rewardPlayer(finalAngle, balance, redSection, blueSection, greenSection, goldSection);
                        
            isRewarded = true;
            textBalance.text = "Balance: " + balance;
        }
    }

    //spins the spinner only when clicking on the transform
    void OnMouseDown(){
        //spins the wheel
        if(isClicked == false){
         this.rotationalSpeed = RandomNumberSpinSpeed(150, 250);

        //subtracts from balance
        balance -= costAmount;
        textBalance.text = "Balance: " + balance;
        isClicked = true;

        //adds spins
        totalSpins += 1;
        }
        //gets a random number to slow it down
        randomRange = RandomNumberSlow(.98f, .99f);
        //resets conditions
        isRewarded = false;
        finalAngleCalculated = false;
       textSpins.text = "Spins: " + totalSpins; 

    }

    //gets a random number to slow
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

    //rewards player

    public static int rewardPlayer(float finalAngle, float balance, int redSection, int blueSection, int greenSection, int goldSection){

        if (finalAngle >= 0 && finalAngle < 29.8){
            balance += redSection;
        }
        else if (finalAngle >= 30 && finalAngle < 59.8){
            balance += greenSection;
        }
        else if (finalAngle >= 60 && finalAngle < 89.8){
            balance += redSection;
        }
        else if (finalAngle >= 90 && finalAngle < 119.8){
            balance += goldSection;
        }
        else if (finalAngle >= 120 && finalAngle <  149.8){
            balance += blueSection;
        }
          else if (finalAngle >= 150 && finalAngle <  179.8){
            balance += greenSection;
        }
         else if (finalAngle >= 180 && finalAngle < 210.8){
            balance += goldSection;
        }
         else if (finalAngle >= 210 && finalAngle < 239.8){
            balance += blueSection;
        }
         else if (finalAngle >= 240 && finalAngle < 269.8){
            balance += redSection;
         }
         else if (finalAngle >= 270 && finalAngle < 299.8){
            balance += goldSection;} 
        else if (finalAngle >= 300 && finalAngle < 329.8){
            balance += blueSection;
        } else if (finalAngle >= 330 && finalAngle < 359.8){
            balance += greenSection;
        }

        return (int)balance;
    }

void FixedUpdate()
{

    // if balance = 0, game over screen displays
    if(balance <= 0 && isRewarded == true)
    {
         SceneManager.LoadScene("sceneGameOver");
         SceneManager.SetActiveScene(SceneManager.GetSceneByName("sceneGameOver"));
    }
}
}