using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasStart : MonoBehaviour
{
    //attached to main camera
    public Canvas welcomeC;
    public Canvas loginC;
    public Canvas signupC;
    public Canvas orderC;
    public Canvas paymentC;
    public Canvas confirmedC;
    void Start()
    {
        welcomeC.gameObject.SetActive(true);
        loginC.gameObject.SetActive(false);
        signupC.gameObject.SetActive(false);
        orderC.gameObject.SetActive(false);
        paymentC.gameObject.SetActive(false);
        confirmedC.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
