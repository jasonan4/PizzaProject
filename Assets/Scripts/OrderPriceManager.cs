using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OrderPriceManager : MonoBehaviour
{
    //Pizza//
    public ToggleGroup toppinglist1;
    public ToggleGroup toppinglist2;
    public ToggleGroup toppinglist3;
    public ToggleGroup toppinglist4;
    //public ToggleGroup crust;
    public ToggleGroup size;
    public Button AddToOrderPizza;
    public Button AddToOrderSides;
    public Button AddToOrderDrinks;
    Toggle selectedTopping1;
    Toggle selectedTopping2;
    Toggle selectedTopping3;
    Toggle selectedTopping4;
    Toggle crustSelection;
    Toggle sizeSelection;

    //Sides//
    [SerializeField] private Text breadSticksAmount;
    [SerializeField] private Text breadBitesAmount;
    [SerializeField] private Text cookieAmount;

    //BEVERAGES//
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

    //Totals
    private double acculatedsubtotal;

    /// <summary>
    /// Calculates the price of the entire meal
    /// </summary>
    /// <returns></returns>
    public double calculatePrice()
    {
        double total = 0.0;
        //sides
        total += calculatedSidePrice();
        //Pizza
        total += calculatedPizzaPrice();
        //Drink
        total += calculatedDrinkPrice();

        return (total);
    }

    /// <summary>
    /// Calculates the price of sides
    /// </summary>
    /// <returns></returns>
    public double calculatedSidePrice()
    {
        double sidePrice = 0.0;
        sidePrice += itemPrice(breadSticksAmount.text, 4.00);//breadsticks
        sidePrice += itemPrice(breadBitesAmount.text, 2.00);//breadbites
        sidePrice += itemPrice(cookieAmount.text, 4.00);//bigCookie
        Debug.Log(sidePrice);

        return sidePrice;
    }
    /// <summary>
    /// Calculates the price of pizza
    /// </summary>
    /// <returns></returns>
    public double calculatedPizzaPrice()
    {
        double pizzaPrice = 0.0;
        pizzaPrice += sizePriceCalc();
        int topamount = pizzaToppings();
        switch (pizzaPrice)
        {
            case 10.00:
                pizzaPrice += 1.25 * topamount;
                break;
            case 8.00:
                pizzaPrice += 1.00 * topamount;
                break;
            case 6.00:
                pizzaPrice += 0.75 * topamount;
                break;
            case 4.00:
                pizzaPrice += 0.50 * topamount;
                break;
        }
        Debug.Log(pizzaPrice);

        return pizzaPrice;
    }

    /// <summary>
    /// Calculates the price of drinks
    /// </summary>
    /// <returns></returns>
    public double calculatedDrinkPrice()
    {
        double drinkPrice = 0.0;
        drinkPrice += drinkCondense(pepsiSmallAmount.text, pepsiMediumAmount.text, pepsiLargeAmount.text);//Pepsi
        drinkPrice += drinkCondense(dietPepsiSmallAmount.text, dietPepsiMediumAmount.text, dietPepsiLargeAmount.text);//Diet Pepsi
        drinkPrice += drinkCondense(orangeSmallAmount.text, orangeMediumAmount.text, orangeLargeAmount.text);//Orange 
        drinkPrice += drinkCondense(dietOrangeSmallAmount.text, dietOrangeMediumAmount.text, dietOrangeLargeAmount.text);//Diet Orange
        drinkPrice += drinkCondense(rootBeerSmallAmount.text, rootBeerMediumAmount.text, rootBeerLargeAmount.text);//Root Beer
        drinkPrice += drinkCondense(dietRootBeerSmallAmount.text, dietRootBeerMediumAmount.text, dietRootBeerLargeAmount.text);//Diet Root Beer
        drinkPrice += drinkCondense(sierraMistSmallAmount.text, sierraMistMediumAmount.text, sierraMistLargeAmount.text);//Sierra Mist
        drinkPrice += drinkCondense(lemonadeSmallAmount.text, lemonadeMediumAmount.text, lemonadeLargeAmount.text);//Lemonade
        Debug.Log(drinkPrice);
        return drinkPrice;
    }

    /// <summary>
    /// Calculates the price of items and works for singular or multiples quantities
    /// </summary>
    /// <param name="s"></param>
    /// <param name="price"></param>
    /// <returns></returns>
    public double itemPrice(string s, double price)
    {
        int quantity = Int32.Parse(s);
        return quantity*price;
    }
    public double drinkCondense(string s, string d, string f)
    {
        int quantity = Int32.Parse(s) + Int32.Parse(d) + Int32.Parse(f);
        return quantity * 1.00;
    }
    /// <summary>
    /// Makes 4 columns of toppings for the user to select from, and makes sure they can ONLY select 4
    /// </summary>
    /// <returns></returns>
    public int pizzaToppings()
    {
        var list1 = toppinglist1.GetComponentsInChildren<Toggle>();
        var list2 = toppinglist2.GetComponentsInChildren<Toggle>();
        var list3 = toppinglist3.GetComponentsInChildren<Toggle>();
        var list4 = toppinglist4.GetComponentsInChildren<Toggle>();
        int toppingcount = 0;
        foreach (Toggle element in list1)
        {
            if (element.isOn == true)
            {
                toppingcount++;
            }
        }
        foreach (Toggle element in list2)
        {
            if (element.isOn == true)
            {
                toppingcount++;
            }
        }
        foreach (Toggle element in list3)
        {
            if (element.isOn == true)
            {
                toppingcount++;
            }
        }
        foreach (Toggle element in list4)
        {
            if (element.isOn == true)
            {
                toppingcount++;
            }
        }
        return toppingcount-1;
    }
    /// <summary>
    /// Sets the price for each of the sizes of pizza
    /// </summary>
    /// <returns></returns>
    public double sizePriceCalc()
    {
        var sizeList = size.GetComponentsInChildren<Toggle>();
        foreach (Toggle element in sizeList)
        {
            if (element.isOn == true)
            {
                switch (element.tag)
                {
                    case "Small":
                        return 4.00;
                        break;
                    case "Medium":
                        return 6.00;
                        break;
                    case "Large":
                        return 8.00;
                        break;
                    case "X-Large":
                        return 10.00;
                        break;
                }
            }
        }
        return 0.0;
    }
}