using System;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class GetInputOnClick : MonoBehaviour
{
    //input fields
    public InputField emailbox;
    public InputField usernamebox;
    public InputField passwordbox;
    public InputField confirmbox;
    public InputField firstnamebox;
    public InputField lastnamebox;
    public InputField phonenumberbox;
    public InputField creditcardbox;
    public InputField addressbox;
    public TextAsset logininfo;
    StreamReader sr;
    //text field variables
    private string email;
    private string username;
    private string password;
    private string confirmPassword;
    private string address;
    private string firstName;
    private string lastName;
    private string phoneNumber;
    private string creditCard;

    //Text Field Variable Validity
    private bool emailV = false;
    private bool usernameV = false;
    private bool passwordV = false;
    private bool confirmPasswordV = false;
    private bool addressV = false;
    private bool firstNameV = false;
    private bool lastNameV = false;
    private bool phoneNumberV = false;
    private bool creditCardV = false;

    void Start()
    {
        sr = new StreamReader(Application.dataPath + "/" + "LoginInformation");
        string dataline = "";
        dataline = sr.ReadLine();
        while (dataline != null)
        {
            Debug.Log(dataline);
            dataline = sr.ReadLine();
        }
        sr.Close();
        Resources.Load("LoginInformation.txt");
    }
    //getting account information on button click
    public void GetInput()
    {
        //Get Input
            //get Email
        string et = emailbox.text;
        setEmail(et);
            //get Username
        string ut = usernamebox.text;
        setUsername(ut);
            //get Password
        string pt = passwordbox.text;
        setPassword(pt);
            //get Confirm
        string ct = confirmbox.text;
        setConfirm(ct);
            //get First Name
        string ft = firstnamebox.text;
        setFirstName(ft);
            //get Last Name
        string lt = lastnamebox.text;
        setLastName(lt);
            //get Phone Number
        string pnt = phonenumberbox.text;
        setPhoneNumber(pnt);
            //get Credt Card
        string cct = creditcardbox.text;
        setCreditCard(cct);
            //get address
        string at = addressbox.text;
        setAddress(at);
        Debug.Log(emailV && usernameV && passwordV && confirmPasswordV && addressV && firstNameV && lastNameV && phoneNumberV && creditCardV);
        if (emailV && usernameV && passwordV && confirmPasswordV && addressV && firstNameV && lastNameV && phoneNumberV && creditCardV)
        {
            //information enter order: char[] username, char[] password, string emailAddress, int[] phoneNumber, string address, string firstName, string lastName, long creditCardNumber
            Account user = new Account(username, password, email, phoneNumber, address, firstName, lastName, creditCard, logininfo);
        }
    }

    public void setEmail(string s)
    {
        emailV = IsValidEmail(s);
        Debug.Log(emailV);
        if (emailV)
        {
            email = s;
        }
    }
    public void setUsername(string s)//char[]
    {
        
        usernameV = (s.Length <= 30);
        Debug.Log(usernameV);
        if(usernameV)
        {
            username = s;
        }
    }
    public void setPassword(string s)//char[]
    {
        passwordV = s.Length <= 30;
        Debug.Log(passwordV);
        if (passwordV)
        {
            password = s;
        }
    }
    public void setConfirm(string s)
    {
        confirmPasswordV = password == s;
        Debug.Log(confirmPasswordV);
        if (confirmPasswordV)
        {
            confirmPassword = s;
        }
    }
    public void setAddress(string s)
    {
        address = s;
        addressV = (s.Length > 1);
    }
    public void setFirstName(string s)
    {
        firstNameV = s != "";
        if (firstNameV) { firstName = s; }
    }
    public void setLastName(string s)
    {
        lastNameV = s != "";
        if (lastNameV) { lastName = s; }
    }
    public void setPhoneNumber(string s)
    {
        bool allnumb = true;
        phoneNumberV = (s.Length == 10 || s.Length == 11);
        Debug.Log(phoneNumberV);
        if (phoneNumberV)
        {
            if (s.Length == 10)
            {
                phoneNumber = s;
            }
            else
            {
                phoneNumber = s.Substring(1);
            }
        }

    }
    public void setCreditCard(string s)//long
    {
        creditCardV = (s.Length >= 14 && s.Length <= 16);
        if (creditCardV)
        {
            creditCard = s;
        }
    }
    //Extra Methods to help validate data
    private bool IsValidEmail(string email)
    {
        if (email.Trim().EndsWith("."))
        {
            return false;
        }
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

}

public class Account 
{
    //Variables
    private string username;
    private string password;
    private string emailAddress;
    private string phoneNumber;
    private string address;
    private string firstName;
    private string lastName;
    private string creditCardNumber;
    private TextAsset txtlog;
    private string path = "Assets/Resources/LoginInformation.txt";

    //constructors
    public Account(string username, string password, string emailAddress, string phoneNumber, string address, string firstName, string lastName, string creditCardNumber, TextAsset txt)
    {
        this.username = username;
        this.password = password;
        this.emailAddress = emailAddress;
        this.phoneNumber = phoneNumber;
        this.address = address;
        this.firstName = firstName;
        this.lastName = lastName;
        this.creditCardNumber = creditCardNumber;
        txtlog = txt;

        saveAccount();
    }

    //Getters and Setters
    public string getUsername()
    {
        return this.username;
    }
    public string getPassword()
    {
        return this.password;
    }
    public string getEmailAddress()
    {
        return this.emailAddress;
    }
    public string getPhoneNumber()
    {
        return this.phoneNumber;
    }
    public string getAddress()
    {
        return this.address;
    }
    public string getFirstName()
    {
        return this.firstName;
    }
    public string getLastName()
    {
        return this.lastName;
    }
    public string getCreditCardNumber()
    {
        return this.creditCardNumber;
    }
    //Methods
    public void saveAccount()
    {
        string c = (" ^&@&^ " + getUsername() + " ^&@&^ " + getPassword() + " ^&@&^ " + getEmailAddress() + " ^&@&^ " + getPhoneNumber() + " ^&@&^ " + getAddress() + " ^&@&^ " + getFirstName() + " ^&@&^ " + getLastName() + " ^&@&^ " + getCreditCardNumber() + " ^&@&^ " + "\n");
        //username password emailaddress phonenumber address firstname lastname cardnumber
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(c);
        writer.Close();

        AssetDatabase.ImportAsset(path);
        var asset = Resources.Load("test");
    }

}