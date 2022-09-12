using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FoodItemNamespace;
namespace OrderNamespace
{
    /// <summary>
    /// Sets all of the toppings, sides and beverages
    /// </summary>
    public class Order
    {
        private LinkedList<FoodItem> beverages;
        private LinkedList<FoodItem> sides;
        private LinkedList<FoodItem> toppings;

        public Order()
        {

        }

        public LinkedList<FoodItem> GetToppings()
        {
            return toppings;
        }

        public LinkedList<FoodItem> GetSides()
        {
            return sides;
        }

        public LinkedList<FoodItem> GetBeverages()
        {
            return beverages;
        }

        public void Add(FoodItem item)
        {
            if (item.GetKind() == "topping")
            {
                toppings.AddLast(item);
            }

            else if (item.GetKind() == "side")
            {
                sides.AddLast(item);
            }

            else if (item.GetKind() == "beverage")
            {
                beverages.AddLast(item);
            }
        }
    }
}