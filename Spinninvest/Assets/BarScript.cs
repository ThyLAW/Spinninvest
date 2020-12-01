using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BarScript : MonoBehaviour
{

    public TextMeshProUGUI sliderText;
    public Slider slider;

    void Start()
    {
        
    }
    public void SetMaxValue(int value)
    {
        slider.maxValue = value;
    }

    public void SetMinValue(int value)
    {
        slider.minValue = value;
    }
    public void SetValue(int value)
    {
        slider.value = value;

        sliderText.text = "Age: " + value;
    }

    public void setMoneyValue(float value)
    {
        slider.value = value;

        sliderText.text = value.ToString("C");
    }
}

//                  public GameObject moneyBar;
//           public GameObject MoneyProgressBar;
//        BarScript MoneyProgressBar = moneyBar.GetComponent<BarScript>();
//         MoneyProgressBar.setMoneyValue(123123);
