using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// attached to every button that switches to a different canvas. takes the current canvas and makes it false, which
/// hides it.
/// Then, it takes the destination canvas and makes it true, which turns it visible.
/// </summary>
public class PageChangingScript : MonoBehaviour
{
    public Canvas fromCanvas; //The canvas traveled from
    public Canvas currentCanvas; //The current canvas
    public Canvas toCanvas; //The canvas to travel to
    public Canvas ElsePage;

    protected Button self;

    public void Start()
    {
        self = GetComponent<Button>();
        self.onClick.AddListener(ActOnClick);
    }

    public void ActOnClick()
    {
        if(LogInStatus.LoggedIn)
        {
            currentCanvas.gameObject.SetActive(false);
            toCanvas.gameObject.SetActive(true);
        }
        else
        {
            currentCanvas.gameObject.SetActive(false);
            ElsePage.gameObject.SetActive(true);
        }
    }

}
