using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuButton : MonoBehaviour
{
    public Canvas fromCanvas; //The canvas traveled from
    public Canvas currentCanvas; //The current canvas
    public Canvas toCanvas; //The canvas to travel to

    protected Button self;

    public void Start()
    {
        InitializeButton();
        self = GetComponent<Button>();
        self.onClick.AddListener(ActOnClick);
    }

    public void ActOnClick()
    {
        currentCanvas.gameObject.SetActive(false);
        toCanvas.gameObject.SetActive(true);
    }

    protected void InitializeButton()
    {

    }
}
