using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour
{
    public float UserMoney;
    static private PlayerMoney P;
    public GameObject moneyBar;
    public static BarScript MoneyProgressBarScript;
    public float starterMoney = 10000;


    //gets the component and sets money to starter money
    void Start()
    {
        P = this;
        BarScript MoneyProgressBarScript = P.moneyBar.GetComponent<BarScript>();
        MoneyProgressBarScript.setMoneyValue(starterMoney);
    }

    //sets the global money variable and then calls barscript function to update the money bar
    public static void SetPlayerMoney(float userMoney)
    {
        BarScript MoneyProgressBarScript = P.moneyBar.GetComponent<BarScript>();
        P.UserMoney = userMoney;
        MoneyProgressBarScript.setMoneyValue(P.UserMoney);

    }

    //getts the players money
    public static float GetPlayerMoney()
    {
        return P.UserMoney;
    }
}
