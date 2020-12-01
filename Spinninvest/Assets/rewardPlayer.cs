using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using DialogueEditor;

public class rewardPlayer : MonoBehaviour
{
    public GameObject spinner;
    public TextMeshProUGUI workIncome;
    public TextMeshProUGUI jobText;
    public TextMeshProUGUI marriedText;
    public float money = 10000;
    public float workMoney = 10000;
    public bool isMarried = false;
    public bool isHired = true;
    public int numberOfKids = 0;
    public bool below0 = false;

    [Header("Red Group")]
    public NPCConversation lostWalletConversation, suedConversation, robbedConversation, gamblingAddictionConversation, luxuryPurchaseConversation;
    [Header("Blue Group")]
    public NPCConversation raiseConversation, lookingForJobConversation, secondJobConversation, vacationConversation, reducedWagesConversation, firedConversation, hiredConversation;
    [Header("Green Group")]
    public NPCConversation successfulLawsuitConversation, inheritanceConversation, wonLotteryConversation, foundMoneyConversation, extraWorkConversation;
    [Header("Gold Group")]
    public NPCConversation buyCompany5000Conversation, takeOnDateConversation, goOnDateConversation, investInStocksConversation, gotMarriedConversation, gotDivorcedConversation, hadKidsConversation, buyRealEstateConversation;

    bool isRewarded = false;
    float finalAngle;
    bool finalAngleCalculated;
    float rotationalSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //gets values from other scripts
        isRewarded = GameObject.Find("Spinner").GetComponent<newSpinnerScript>().isRewarded;
        finalAngle = GameObject.Find("Spinner").GetComponent<newSpinnerScript>().finalAngle;
        finalAngleCalculated = GameObject.Find("Spinner").GetComponent<newSpinnerScript>().finalAngleCalculated;
        rotationalSpeed = GameObject.Find("Spinner").GetComponent<newSpinnerScript>().rotationalSpeed;

        //updates the text in game to represent values
        workIncome.text = "Daily Income: " + workMoney.ToString("C");
        marriedText.text = "Married: " + isMarried.ToString();
        jobText.text = "Employed: " + isHired.ToString();

        // if below 0 turns true and ends game from game over script
        if(money <= 0)
        {
            below0 = true;
        }
        //rewards the player only once
        if (rotationalSpeed == 0 && isRewarded == false && finalAngleCalculated == true) {
            rewardThePlayer();
            isRewarded = true;
            GameObject.Find("Spinner").GetComponent<newSpinnerScript>().isRewarded = true;
        }

    }

    //fires event and updates money
    void rewardThePlayer()
    {
        if (finalAngle > 0 && finalAngle <= 30)
        {
            Debug.Log("Red");
            RedGroupEvents();

        }
        else if (finalAngle > 30 && finalAngle <= 60)
        {
            Debug.Log("Green");
            GreenGroupEvents();
        }
        else if (finalAngle > 60 && finalAngle <= 90)
        {
            Debug.Log("Red");
            RedGroupEvents();
        }
        else if (finalAngle > 90 && finalAngle <= 120)
        {
            Debug.Log("Gold");
            GoldGroupEvents();
        }
        else if (finalAngle > 120 && finalAngle <= 150)
        {
            Debug.Log("Blue");
            BlueGroupEvents();
        }
        else if (finalAngle > 150 && finalAngle <= 180)
        {
            Debug.Log("Green");
            GreenGroupEvents();
        }
        else if (finalAngle > 180 && finalAngle <= 210)
        {
            Debug.Log("Gold");
            GoldGroupEvents();
        }
        else if (finalAngle > 210 && finalAngle <= 240)
        {
            Debug.Log("Blue");
            BlueGroupEvents();
        }
        else if (finalAngle > 240 && finalAngle <= 270)
        {
            Debug.Log("Red");
            RedGroupEvents();
        }
        else if (finalAngle > 270 && finalAngle <= 300)
        {           
            Debug.Log("Gold");
            GoldGroupEvents();

        }
        else if (finalAngle > 300 && finalAngle <= 330)
        {
            Debug.Log("Blue");
            BlueGroupEvents();
        }
        else if (finalAngle > 330 && finalAngle <= 360)
        {
            Debug.Log("Green");
            GreenGroupEvents();
        }
        money += workMoney;
        PlayerMoney.SetPlayerMoney(money);
    }

    // chooses a random number for different life events
    public int RandomNumberPicker(int number, int number2)
    {
        int return1 = Random.Range(number, number2);
        return return1;
    }

    //creates the different groups of events

    // negative events
    public void RedGroupEvents()
    {
        int minEvents = 1;
        int MaxEvents = 5;
        int result = 0;
        result = RandomNumberPicker(minEvents, MaxEvents);
        Debug.Log(result);
        if (result == 1)
        {
            ConversationManager.Instance.StartConversation(robbedConversation);
        }
        if (result == 2)
        {
            ConversationManager.Instance.StartConversation(lostWalletConversation);
        }
        if (result == 3)
        {
            ConversationManager.Instance.StartConversation(suedConversation);
        }
        if (result == 4)
        {
            ConversationManager.Instance.StartConversation(gamblingAddictionConversation);
        }
        if (result == 5)
        {
            ConversationManager.Instance.StartConversation(luxuryPurchaseConversation);
        }
    }

    public void GreenGroupEvents()
    {
        int minEvents = 1;
        int MaxEvents = 5;
        int result;
        result = RandomNumberPicker(minEvents, MaxEvents);
        Debug.Log(result);
        if (result == 1)
        {
            ConversationManager.Instance.StartConversation(foundMoneyConversation);
        }
        if (result == 2)
        {
            ConversationManager.Instance.StartConversation(wonLotteryConversation);
        }
        if (result == 3)
        {
            ConversationManager.Instance.StartConversation(successfulLawsuitConversation);
        }
        if (result == 4)
        {
            ConversationManager.Instance.StartConversation(inheritanceConversation);
        }
        if (result == 5)
        {
            ConversationManager.Instance.StartConversation(extraWorkConversation);
        }
    }

    public void BlueGroupEvents()
    {
        int minEvents = 1;
        int MaxEvents = 6;
        int result;
        result = RandomNumberPicker(minEvents, MaxEvents);
        Debug.Log(result);

        if (result == 1)
        {
            ConversationManager.Instance.StartConversation(raiseConversation);
        }
        if (result == 2 && isHired == true)
        {
            ConversationManager.Instance.StartConversation(firedConversation);
        }
        if (result == 2 && isHired == false)
        {
            ConversationManager.Instance.StartConversation(lookingForJobConversation);
        }
        if (result == 3 && isHired == false)
        {
            ConversationManager.Instance.StartConversation(hiredConversation);
        }
        if (result == 3 && isHired == true)
        {
            ConversationManager.Instance.StartConversation(secondJobConversation);
        }
        if (result == 4)
        {
            ConversationManager.Instance.StartConversation(vacationConversation);
        }
        if (result == 5)
        {
            ConversationManager.Instance.StartConversation(reducedWagesConversation);
        }
        if (result == 6)
        {
            ConversationManager.Instance.StartConversation(secondJobConversation);
        }
    }

    public void GoldGroupEvents()
    {
        int minEvents = 1;
        int MaxEvents = 6;
        int result;
        result = RandomNumberPicker(minEvents, MaxEvents);
        Debug.Log(result);
        if (result == 1)
        {
            ConversationManager.Instance.StartConversation(hadKidsConversation);
        }
        if (result == 2 && isMarried == true)
        {
            ConversationManager.Instance.StartConversation(takeOnDateConversation);
        }
        if (result == 2 && isMarried == false)
        {
            ConversationManager.Instance.StartConversation(gotMarriedConversation);
        }
        if (result == 3 && isMarried == true)
        {
            ConversationManager.Instance.StartConversation(gotDivorcedConversation);
        }
        if (result == 3 && isMarried == false)
        {
            ConversationManager.Instance.StartConversation(goOnDateConversation);
        }
        if (result == 4)
        {
            ConversationManager.Instance.StartConversation(buyCompany5000Conversation);
        }
        if (result == 5)
        {
            ConversationManager.Instance.StartConversation(investInStocksConversation);
        }
        if (result == 6)
        {
            ConversationManager.Instance.StartConversation(buyRealEstateConversation);
        }


    }

    // creates the different events
   
    // red group
    public void GetRobbed()
    {
        money = money * .90f;
        PlayerMoney.SetPlayerMoney(money);

    }
    public void LoseWallet()
    {
        money = money * .90f;
        PlayerMoney.SetPlayerMoney(money);

    }
    public void GetSued()
    {
        money = money - 30000;
        PlayerMoney.SetPlayerMoney(money);

    }
    public void SueBack()
    {   
        // 50 perecnt chance to win, 0 change, if lsoe, -100k
        int result;
        result = RandomNumberPicker(0, 10);
        if (result <=4)
        {
            money = money - 60000;
        }
        else if(result >= 5)
        {
            Debug.Log("Won Lawsuit");
        }
        PlayerMoney.SetPlayerMoney(money);

    }
    public void GamblingAddict()
    {
        money = money * .70f;
        PlayerMoney.SetPlayerMoney(money);

    }
    public void MakeLuxuryPurchase()
    {
        money = money - 50000;
        PlayerMoney.SetPlayerMoney(money);

    }
    //blue group

    public void GetRaise()
    {
        workMoney += 4000;
        PlayerMoney.SetPlayerMoney(money);

    }
    public void TakeVacation()
    {
        money = money + 50000;
        PlayerMoney.SetPlayerMoney(money);

    }
    public void ReduceWages()
    {
        workMoney -= 4000;
        PlayerMoney.SetPlayerMoney(money);

    }
    public void GetFired()
    {
        workMoney -= 10000;
        isHired = false;
        PlayerMoney.SetPlayerMoney(money);

    }
    public void GetHired()
    {
        workMoney += 10000;
        isHired = true;
        PlayerMoney.SetPlayerMoney(money);

    }

    public void SideJob()
    {
        workMoney += 1000;
        PlayerMoney.SetPlayerMoney(money);
    }

        //green group
        public void SuccessfulLawsuit()
    {
        money += 50000;
        PlayerMoney.SetPlayerMoney(money);

    }
    public void FoundMoney()
    {
        money += 500;
        PlayerMoney.SetPlayerMoney(money);

    }
    public void WonLottery()
    {
        money += 50000;
        PlayerMoney.SetPlayerMoney(money);

    }
    public void DoExtraWork()
    {
        money += 1000;
        PlayerMoney.SetPlayerMoney(money);

    }
    public void GetInheritance()
    {
        money += 100000;
        PlayerMoney.SetPlayerMoney(money);

    }
    //gold group
    public void StartCompany()
    {
        money -= 15000;
        workMoney += 2000;
        PlayerMoney.SetPlayerMoney(money);

    }

    public void HaveKids()
    {
        workMoney -= 3000;
        numberOfKids += 1;
        PlayerMoney.SetPlayerMoney(money);

    }
    public void GotMarried()
    {
        workMoney += 5000;
        isMarried = true;
        PlayerMoney.SetPlayerMoney(money);

    }
    public void GotDivorced()
    {
        money = money *= .50f;
        isMarried = false;
        PlayerMoney.SetPlayerMoney(money);

    }
    public void BuyRealEstate()
    {
        workMoney += 5000;
        PlayerMoney.SetPlayerMoney(money);

    }
    public void InvestInStocks()
    {
        money -= 10000;
        workMoney += 500;
        PlayerMoney.SetPlayerMoney(money);

    }

    public void Dates()
    {
        money -= 500;
        PlayerMoney.SetPlayerMoney(money);

    }

}
