using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToSignUpCanvas : MonoBehaviour
{
    public Canvas fromCanvas; //The canvas traveled from
    public Canvas currentCanvas; //The current canvas
    public Canvas toCanvas; //The canvas to travel to


    protected Button self;

    public void Start()
    {
        self = GetComponent<Button>();
        self.onClick.AddListener(ActOnClick);
    }

    public void ActOnClick()
    {
        toCanvas.gameObject.SetActive(true);
        currentCanvas.gameObject.SetActive(false);
        toCanvas.gameObject.SetActive(true); 
    }
}
