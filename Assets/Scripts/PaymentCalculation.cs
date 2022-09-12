using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class PaymentCalculation : MonoBehaviour
{
    /// <summary>
    /// Calculates the tip that the customer chooses.
    /// </summary>
    [SerializeField] private Text tipAmountText;
    [SerializeField] private Text totalText;
    [SerializeField] private Text subTotalText;
    [SerializeField] private Text salesTaxText;
    [SerializeField] private Text customTipText;
    public ToggleGroup tips;
    double customTipAmount = 0.0;
    private double tip;
    private double subtotal;
    private string st;
    

    void Start()
    {
    }
    void Update()
    {

        Debug.Log(subTotalText.text);
        st = subTotalText.text;
        subtotal = Double.Parse(st.Substring(1));
        tipAmountText.text = DoubleToDollar(calculateTip());
        totalText.text = DoubleToDollar((0.04 * subtotal) + subtotal + calculateTip());
    }
    public void updateCustom(string s)
    {
        if(s.Length > 0)
        {
            customTipAmount = Double.Parse(s);
        }
        else
        {
            customTipAmount = 0.00;
        }
        
    }

    /// <summary>
    /// Prints the payment in a string variable
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    private string DoubleToDollar(double d)
    {
        int pass1 = (int)(d * 100);
        string dstr = (pass1 + "");
        string dollars = (pass1 / 100) + "";
        string cents = (pass1 % 100) + "";
        if (cents.Length < 2)
        {
            cents = "0" + cents;
        }
        return "$" + dollars + "." + cents;
    }
    /// <summary>
    /// Calculates the tip that the customer selects
    /// </summary>
    /// <returns></returns>
    public double calculateTip()
    {
        var tipList = tips.GetComponentsInChildren<Toggle>();
        foreach (Toggle element in tipList)
        {
            if (element.isOn == true)
            {
                switch (element.tag)
                {

                    case ".10":
                        return subtotal * 0.10;
                        break;
                    case ".15":
                        return subtotal * 0.15;
                        break;
                    case ".20":
                        return subtotal * 0.20;
                        break;
                    case "custom":
                        tip = customTipAmount;
                        break;

                }

            }
        }
        return tip;
    }
}
