using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This small class allows us to combine the name of a food item with its size
//for easier processing of orders
namespace FoodItemNamespace
{
    public class FoodItem
    {
        new private string name;

        //0 is none or n/a, 1 is small, 2 is medium, 3 is large
        private int size;

        private string kind;

        private double price;

        public FoodItem(string name, string kind, int size)
        {
            this.name = name;
            this.size = size;
            this.kind = kind;
        }

        public FoodItem(string name, string kind, int size, double price)
        {
            this.name = name;
            this.size = size;
            this.kind = kind;
            this.price = price;
        }

        public void SetName(string name)
        {
            this.name = name;
        }

        public void SetSize(int size)
        {
            this.size = size;
        }

        public void SetKind(string kind)
        {
            this.kind = kind;
        }
        public string GetName()
        {
            return name;
        }

        public int GetSize()
        {
            return size;
        }

        public string GetKind()
        {
            return kind;
        }

        public double GetPrice()
        {
            return price;
        }
    }
}