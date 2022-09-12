using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script is attached to every arrow button on the order paged.
/// Used to increase or decrease the item quantity desplayed in the adjacent text boxes
/// </summary>
public class ArrowButtons : MonoBehaviour
{
    /// <summary>
    /// Amount is the variable that is input into the system and changes whenever a button is clicked.
    /// </summary>
    public Text t;
    int amount;
    protected Button self;
    Text ButtonText;
    string bt;
    void Start()
    {
        self = GetComponent<Button>();
        self.onClick.AddListener(ActOnClick);
        ButtonText = self.GetComponentInChildren(typeof(Text)) as Text;
        bt = ButtonText.text;
    }
    /// <summary>
    /// if a button's text is '<' and the amount is greater than zero, it will decrease the quantity
    /// if a button's text is '>', it will increase the quantity
    /// </summary>
    public void ActOnClick()
    {
        if(bt == ">")
        {
            amount = Convert.ToInt32(t.text) + 1;
        }
        else if(bt == "<" && Convert.ToInt32(t.text) > 0)
        {
            amount = Convert.ToInt32(t.text) - 1;
        }
        t.text = amount.ToString();
    }

}
