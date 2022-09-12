using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddPizza : MonoBehaviour
{
    /// <summary>
    /// holds all of the toggles for everything to do with pizza.
    /// </summary>
    protected Button self;
    Toggle smallToggle;
    Toggle mediumToggle;
    Toggle largeToggle;
    Toggle xlargeToggle;
    Toggle thinCrust;
    Toggle regularCrust;
    Toggle panCrust;
    Toggle cheese;
    Toggle pepperoni;
    Toggle sausage;
    Toggle ham;
    Toggle greenPepper;
    Toggle onion;
    Toggle tomato;
    Toggle mushroom;
    Toggle pineapple;
    int toppingCount;
    double price;
    // Start is called before the first frame update
    /// <summary>
    /// Makes sure that all of the toggles can actually be selected.
    /// </summary>
    void Start()
    {
        self = GetComponent<Button>();
        self.onClick.AddListener(ActOnClick);
        smallToggle = GameObject.Find("SmallToggle").GetComponent<Toggle>();
        mediumToggle = GameObject.Find("MediumToggle").GetComponent<Toggle>();
        largeToggle = GameObject.Find("LargeToggle").GetComponent<Toggle>();
        xlargeToggle = GameObject.Find("XLargeToggle").GetComponent<Toggle>();
        thinCrust = GameObject.Find("ThinToggle").GetComponent<Toggle>();
        regularCrust = GameObject.Find("RegularToggle").GetComponent<Toggle>();
        panCrust = GameObject.Find("PanToggle").GetComponent<Toggle>();
        cheese = GameObject.Find("CheeseToggle").GetComponent<Toggle>();
        pepperoni = GameObject.Find("PepperoniToggle").GetComponent<Toggle>();
        sausage = GameObject.Find("SausageToggle").GetComponent<Toggle>();
        ham = GameObject.Find("HamToggle").GetComponent<Toggle>();
        greenPepper = GameObject.Find("GreenPepperToggle").GetComponent<Toggle>();
        onion = GameObject.Find("OnionToggle").GetComponent<Toggle>();
        tomato = GameObject.Find("TomatoToggle").GetComponent<Toggle>();
        mushroom = GameObject.Find("MushroomToggle").GetComponent<Toggle>();
        pineapple = GameObject.Find("PineappleToggle").GetComponent<Toggle>();
    }

    public void ActOnClick()
    {
       /* if (smallToggle.isOn == true || mediumToggle.isOn == true || largeToggle.isOn == true || xlargeToggle.isOn == true)
        {
            if (thinCrust.isON = true || regularCrust.isON = true || panCrust.isON = true)
            {
                if (cheese.isON = true)
                {
                    toppingCount++;
                }
                if (pepperoni.isON = true)
                {
                    toppingCount++;
                }
                if (sausage.isON = true)
                {
                    toppingCount++;
                }
                if (ham.isON = true)
                {
                    toppingCount++;
                }
                if (greenPepper.isON = true)
                {
                    toppingCount++;
                }
                if (onion.isON = true)
                {
                    toppingCount++;
                }
                if (tomato.isON = true)
                {
                    toppingCount++;
                }
                if (mushroom.isON = true)
                {
                    toppingCount++;
                }
                if (pineapple.isON = true)
                {
                    toppingCount++;
                }
            }
        }
        if (smallToggle.isON = true)
        {
            price = 4 + ((toppingCount - 1) * 0.5);
        }
        else if (mediumToggle.isON = true)
        {
            price = 6 + ((toppingCount - 1) * 0.75);
        }
        else if (largeToggle.isON = true)
        {
            price = 8 + ((toppingCount - 1) * 1);
        }
        else if (xlargeToggle.isON = true)
        {
            price = 10 + ((toppingCount - 1) * 1.25);
        }
       */
    }

    // Update is called once per frame
    void Update()
    {

    }
}
