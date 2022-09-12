using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//attached to the order canvas
public class OrderManager : MonoBehaviour
{
    //The "Amounts" empty gameobject in the hierarchy.
    //This is used for hierarchy-based iteration.
    private string BeveragePrint = "Beverage:\n";
    private string SidesPrint = "Sides:\n";
    public double subtotal = 0.0;
    private double tipTotal = 0.0;
    public OrderPriceManager orderPricer;


    //  TOPPINGS  //
    string temp;
    double price;
    int toppingCount = 0;
    public ToggleGroup toppinglist1;
    public ToggleGroup toppinglist2;
    public ToggleGroup toppinglist3;
    public ToggleGroup toppinglist4;
    public ToggleGroup crust;
    public ToggleGroup size;
    public ToggleGroup tips;
    public Button AddToOrderPizza;
    public Button AddToOrderSides;
    public Button AddToOrderDrinks;
    public GameObject tipTen;
    public GameObject tipFifteen;
    public GameObject tipTwenty;
    public GameObject tipCustom;
    private double tip;
    double customTipAmount = 0.0;
    public Text customTipText;
    Toggle selectedTopping1;
    Toggle selectedTopping2;
    Toggle selectedTopping3;
    Toggle selectedTopping4;
    Toggle crustSelection;
    Toggle sizeSelection;
    public Text paymentText;
    List<string> current = new List<string>();
    List<string> currentDrinks = new List<string>();
    string pizzacrust;
    string pizzasize;
    //PaymentCalculation calculator;
    public Canvas orderCanvas;

    [SerializeField] private Text subTotalText;
    [SerializeField] private Text salesTaxText;
    [SerializeField] private Text TipAmountText;
    [SerializeField] private Text TotalText;
    public void retrievePizza()
    {
        
        var list1 = toppinglist1.GetComponentsInChildren<Toggle>();
        var list2 = toppinglist2.GetComponentsInChildren<Toggle>();
        var list3 = toppinglist3.GetComponentsInChildren<Toggle>();
        var list4 = toppinglist4.GetComponentsInChildren<Toggle>();
        var crustList = crust.GetComponentsInChildren<Toggle>();
        var sizeList = size.GetComponentsInChildren<Toggle>();
        foreach (Toggle element in list1)
        {
            if (element.isOn == true)
            {
                selectedTopping1 = element;
                current.Add(element.tag);
                toppingCount++;
            }
        }
        foreach (Toggle element in list2)
        {
            if (element.isOn == true)
            {
                selectedTopping2 = element;
                current.Add(element.tag);
                toppingCount++;
            }
        }
        foreach (Toggle element in list3)
        {
            if (element.isOn == true)
            {
                selectedTopping3 = element;
                current.Add(element.tag);
                toppingCount++;
            }
        }
        foreach (Toggle element in list4)
        {
            if (element.isOn == true)
            {
                selectedTopping4 = element;
                current.Add(element.tag);
                toppingCount++;
            }
        }
        foreach (Toggle element in crustList)
        {
            if (element.isOn == true)
            {
                pizzacrust = element.tag;
            }
        }
        foreach (Toggle element in sizeList)
        {
            if (element.isOn == true)
            {
                pizzasize = element.tag;
                if (element.tag == "Small")
                {
                    price = 4.00f + (toppingCount - 1) * 0.50;
                }
                if (element.tag == "Medium")
                {
                    price = 6.00f + (toppingCount - 1) * 0.75; ;
                }
                if (element.tag == "Large")
                {
                    price = 8.00f + (toppingCount - 1) * 1.00; ;
                }
                if (element.tag == "X-Large")
                {
                    price = 10.00f + (toppingCount - 1) * 1.25; ;
                }
            }
        }

    }

    void Start()
    {
        AddToOrderPizza.onClick.AddListener(TaskOnClickPizza);
        AddToOrderSides.onClick.AddListener(TaskOnClickSides);
        AddToOrderDrinks.onClick.AddListener(TaskOnClickDrinks);
        OrderPriceManager orderPricer = GetComponent<OrderPriceManager>();
        tipTen = GameObject.Find("10%Tip");
        tipFifteen = GameObject.Find("15%Tip");
        tipTwenty = GameObject.Find("20%Tip");
        tipCustom = GameObject.Find("CustomTip");
    }
    void Update()
    {
        customTipAmount = Double.Parse("0.00");
        //tipTotal = calculateTip();
        subTotalText.text = DoubleToDollar(subtotal);
        salesTaxText.text = DoubleToDollar(0.04 * subtotal);
        TipAmountText.text = DoubleToDollar(tipTotal);
        //TotalText.text = DoubleToDollar((0.04 * subtotal) + subtotal + tipTotal);
    }
    public double getSubTotal()
    {
        return subtotal;
    }
    private string DoubleToDollar(double d)
    {
        int pass1 = (int)(d * 100);
        string dstr = (pass1 + "");
        string dollars = (pass1/100)+"";
        string cents = (pass1 % 100)+"";
        if(cents.Length < 2)
        {
            cents = "0" + cents;
        }
        return "$"+dollars+"."+cents;
    }
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
                        tip = subtotal * 0.10;
                        break;
                    case ".15":
                        tip = subtotal * 0.15;
                        break;
                    case ".20":
                        tip = subtotal * 0.20;
                        break;
                    case "custom":
                        tip = customTipAmount;
                        break;
                    
                }
                
            }
        }
        return tip;
        
    }
    void TaskOnClickPizza()
    {
        FinalizeToppings();
        var list1 = toppinglist1.GetComponentsInChildren<Toggle>();
        var list2 = toppinglist2.GetComponentsInChildren<Toggle>();
        var list3 = toppinglist3.GetComponentsInChildren<Toggle>();
        var list4 = toppinglist4.GetComponentsInChildren<Toggle>();
        var crustList = crust.GetComponentsInChildren<Toggle>();
        var sizeList = size.GetComponentsInChildren<Toggle>();
        foreach (Toggle element in list1)
        {
            if (element.isOn == true)
            {
                element.isOn = false;
            }
        }
        foreach (Toggle element in list2)
        {
            if (element.isOn == true)
            {
                element.isOn = false;
            }
        }
        foreach (Toggle element in list3)
        {
            if (element.isOn == true)
            {
                element.isOn = false;
            }
        }
        foreach (Toggle element in list4)
        {
            if (element.isOn == true)
            {
                element.isOn = false;
            }
        }
        foreach (Toggle element in crustList)
        {
            if (element.isOn == true)
            {
                element.isOn = false;
            }
        }
        foreach (Toggle element in sizeList)
        {
            if (element.isOn == true)
            {
                element.isOn = false;
            }
        }
    }
    void TaskOnClickSides()
    {
        subtotal += orderPricer.calculatedPizzaPrice();
        retrieveSides();
        if (SidesPrint.Length > 7)
        {
            paymentText.text += SidesPrint;
            SidesPrint = "Sides:\n";
        }
    }
    void TaskOnClickDrinks()
    {
        subtotal += orderPricer.calculatedDrinkPrice();
        retrieveDrinks();
        if (BeveragePrint.Length > 9)
        {
            paymentText.text += BeveragePrint;
            BeveragePrint = "Beverage:\n";
        }
    }

    //  SIDES  //
    [SerializeField] private Text breadSticksAmount;
    [SerializeField] private Text breadBitesAmount;
    [SerializeField] private Text cookieAmount;
    //--END SIDES--//
    public void retrieveSides()
    {
        for(int i = 0; i < Int32.Parse(breadSticksAmount.text); i++)
        {
            SidesPrint += "- Bread Sticks $4.00 \n";
        }
        breadSticksAmount.text = "0";
        for (int i = 0; i < Int32.Parse(breadBitesAmount.text); i++)
        {
            SidesPrint += "- Bread Bites $2.00 \n";
        }
        breadBitesAmount.text = "0";
        for (int i = 0; i < Int32.Parse(cookieAmount.text); i++)
        {
            SidesPrint += "- Big Chocolate Chip Cookie $4.00 \n";
        }
        cookieAmount.text = "0";
    }

    //  BEVERAGES  //
    [SerializeField] private Text pepsiSmallAmount;
    [SerializeField] private Text pepsiMediumAmount;
    [SerializeField] private Text pepsiLargeAmount;

    [SerializeField] private Text dietPepsiSmallAmount;
    [SerializeField] private Text dietPepsiMediumAmount;
    [SerializeField] private Text dietPepsiLargeAmount;

    [SerializeField] private Text orangeSmallAmount;
    [SerializeField] private Text orangeMediumAmount;
    [SerializeField] private Text orangeLargeAmount;

    [SerializeField] private Text dietOrangeSmallAmount;
    [SerializeField] private Text dietOrangeMediumAmount;
    [SerializeField] private Text dietOrangeLargeAmount;

    [SerializeField] private Text rootBeerSmallAmount;
    [SerializeField] private Text rootBeerMediumAmount;
    [SerializeField] private Text rootBeerLargeAmount;

    [SerializeField] private Text dietRootBeerSmallAmount;
    [SerializeField] private Text dietRootBeerMediumAmount;
    [SerializeField] private Text dietRootBeerLargeAmount;

    [SerializeField] private Text sierraMistSmallAmount;
    [SerializeField] private Text sierraMistMediumAmount;
    [SerializeField] private Text sierraMistLargeAmount;

    [SerializeField] private Text lemonadeSmallAmount;
    [SerializeField] private Text lemonadeMediumAmount;
    [SerializeField] private Text lemonadeLargeAmount;
    //--END BEVERAGES--//
    public void retrieveDrinks()
    {
        //Pepsi
        if (Int32.Parse(pepsiSmallAmount.text) > 0)
        {
            for(int i = 0; i < Int32.Parse(pepsiSmallAmount.text); i++)
            {
                BeveragePrint += "-" + "Small Pepsi  $1.00\n";
            }
            pepsiSmallAmount.text = "0";
        }
        if (Int32.Parse(pepsiMediumAmount.text) > 0)
        {
            for (int i = 0; i < Int32.Parse(pepsiMediumAmount.text); i++)
                BeveragePrint += "-" + "Medium Pepsi  $1.00\n";
            pepsiMediumAmount.text = "0";
        }
        if (Int32.Parse(pepsiLargeAmount.text) > 0)
        {
            for (int i = 0; i < Int32.Parse(pepsiLargeAmount.text); i++)
                BeveragePrint += "-" + "Large Pepsi  $1.00\n";
            pepsiLargeAmount.text = "0";
        }
        //Diet Pepsi
        if (Int32.Parse(dietPepsiSmallAmount.text) > 0)
        {
            for (int i = 0; i < Int32.Parse(dietPepsiSmallAmount.text); i++)
                BeveragePrint += "-" + "Small Diet Pepsi  $1.00\n";
            dietPepsiSmallAmount.text = "0";
        }
        if (Int32.Parse(dietPepsiMediumAmount.text) > 0)
        {
            for (int i = 0; i < Int32.Parse(dietPepsiMediumAmount.text); i++)
                BeveragePrint += "-" + "Medium Diet Pepsi  $1.00\n";
            dietPepsiMediumAmount.text = "0";
        }
        if (Int32.Parse(dietPepsiLargeAmount.text) > 0)
        {
            for (int i = 0; i < Int32.Parse(dietPepsiLargeAmount.text); i++)
                BeveragePrint += "-" + "Large Diet Pepsi  $1.00\n";
            dietPepsiLargeAmount.text = "0";
        }
        //Orange
        if (Int32.Parse(orangeSmallAmount.text) > 0)
        {
            for (int i = 0; i < Int32.Parse(orangeSmallAmount.text); i++)
                BeveragePrint += "-" + "Small Orange  $1.00\n";
            orangeSmallAmount.text = "0";
        }
        if (Int32.Parse(orangeMediumAmount.text) > 0)
        {
            for (int i = 0; i < Int32.Parse(orangeMediumAmount.text); i++)
                BeveragePrint += "-" + "Medium Orange  $1.00\n";
            orangeMediumAmount.text = "0";
        }
        if (Int32.Parse(orangeLargeAmount.text) > 0)
        {
            for (int i = 0; i < Int32.Parse(orangeLargeAmount.text); i++)
                BeveragePrint += "-" + "Large Orange  $1.00\n";
            orangeLargeAmount.text = "0";
        }
        //Diet Orange
        if (Int32.Parse(dietOrangeSmallAmount.text) > 0)
        {
            for (int i = 0; i < Int32.Parse(dietOrangeSmallAmount.text); i++)
                BeveragePrint += "-" + "Small Diet Orange  $1.00\n";
            dietOrangeSmallAmount.text = "0";
        }
        if (Int32.Parse(dietOrangeMediumAmount.text) > 0)
        {
            for (int i = 0; i < Int32.Parse(dietOrangeMediumAmount.text); i++)
                BeveragePrint += "-" + "Medium Diet Orange  $1.00\n";
            dietOrangeMediumAmount.text = "0";
        }
        if (Int32.Parse(dietOrangeLargeAmount.text) > 0)
        {
            for (int i = 0; i < Int32.Parse(dietOrangeLargeAmount.text); i++)
                BeveragePrint += "-" + "Large Diet Orange  $1.00\n";
            dietOrangeLargeAmount.text = "0";
        }
        //Root Beer
        if (Int32.Parse(rootBeerSmallAmount.text) > 0)
        {
            for (int i = 0; i < Int32.Parse(rootBeerSmallAmount.text); i++)
                BeveragePrint += "-" + "Small Root Beer  $1.00\n";
            rootBeerSmallAmount.text = "0";
        }
        if (Int32.Parse(rootBeerMediumAmount.text) > 0)
        {
            for (int i = 0; i < Int32.Parse(rootBeerMediumAmount.text); i++)
                BeveragePrint += "-" + "Medium Root Beer  $1.00\n";
            rootBeerMediumAmount.text = "0";
        }
        if (Int32.Parse(rootBeerLargeAmount.text) > 0)
        {
            for (int i = 0; i < Int32.Parse(rootBeerLargeAmount.text); i++)
                BeveragePrint += "-" + "Large Root Beer  $1.00\n";
            rootBeerLargeAmount.text = "0";
        }
        //Diet Root Beer
        if (Int32.Parse(dietRootBeerSmallAmount.text) > 0)
        {
            for (int i = 0; i < Int32.Parse(dietRootBeerSmallAmount.text); i++)
                BeveragePrint += "-" + "Small Diet Root Beer  $1.00\n";
            dietRootBeerSmallAmount.text = "0";
        }
        if (Int32.Parse(dietRootBeerMediumAmount.text) > 0)
        {
            for (int i = 0; i < Int32.Parse(dietRootBeerMediumAmount.text); i++)
                BeveragePrint += "-" + "Medium Diet Root Beer  $1.00\n";
            dietRootBeerMediumAmount.text = "0";
        }
        if (Int32.Parse(dietOrangeLargeAmount.text) > 0)
        {
            for (int i = 0; i < Int32.Parse(dietOrangeLargeAmount.text); i++)
                BeveragePrint += "-" + "Large Diet Root Beer  $1.00\n";
            dietOrangeLargeAmount.text = "0";
        }
        //Sierra Mist
        if (Int32.Parse(sierraMistSmallAmount.text) > 0)
        {
            for (int i = 0; i < Int32.Parse(sierraMistSmallAmount.text); i++)
                BeveragePrint += "-" + "Small Sierra Mist  $1.00\n";
            sierraMistSmallAmount.text = "0";
        }
        if (Int32.Parse(sierraMistMediumAmount.text) > 0)
        {
            for (int i = 0; i < Int32.Parse(sierraMistMediumAmount.text); i++)
                BeveragePrint += "-" + "Medium Sierra Mist  $1.00\n";
            sierraMistMediumAmount.text = "0";
        }
        if (Int32.Parse(sierraMistLargeAmount.text) > 0)
        {
            for (int i = 0; i < Int32.Parse(sierraMistLargeAmount.text); i++)
                BeveragePrint += "-" + "Large Sierra Mist  $1.00\n";
            sierraMistLargeAmount.text = "0";
        }
        //Lemonade
        if (Int32.Parse(lemonadeSmallAmount.text) > 0)
        {
            for (int i = 0; i < Int32.Parse(lemonadeSmallAmount.text); i++)
                BeveragePrint += "-" + "Small Lemonade  $1.00\n";
            lemonadeSmallAmount.text = "0";
        }
        if (Int32.Parse(lemonadeMediumAmount.text) > 0)
        {
            for (int i = 0; i < Int32.Parse(lemonadeMediumAmount.text); i++)
                BeveragePrint += "-" + "Medium Lemonade  $1.00\n";
            lemonadeMediumAmount.text = "0";
        }
        if (Int32.Parse(lemonadeLargeAmount.text) > 0)
        {
            for (int i = 0; i < Int32.Parse(lemonadeLargeAmount.text); i++)
                BeveragePrint += "-" + "Large Lemonade  $1.00\n";
            lemonadeLargeAmount.text = "0";
        }

    }

    public void FinalizeToppings()
    {
        retrievePizza();
        paymentText.text += printPizza(current, pizzacrust, pizzasize, price);
        current.Clear();
        toppingCount = 0;
    }
    public string printPizza(List<string> list, string crust, string size, double price)
    {
        temp = "";
        foreach (string element in list)
        {
            temp += "-" + element + "\n";
        }
        if(crust != "" && size != "" && list.Count() > 0)
        {
            subtotal += orderPricer.calculatedPizzaPrice();
            return "Pizza: \n" +
                "Crust: " + crust +
                "\nSize: " + size +
                "\nToppings: \n" + temp +
                "Price: $" + price + "\n\n";
        }
        return "";
    }

    public void FinalizeSides()
    {

    }
}
