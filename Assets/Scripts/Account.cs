using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Accounts
{
    /// <summary>
    /// Simply gets and sets the account info
    /// </summary>
    public class Account : MonoBehaviour
    {
        //Variables
        private char[] username = new char[30];
        private char[] password = new char[30];
        private string emailAddress;
        private char[] phoneNumber = new char[12];
        private string address;
        private string firstName;
        private string lastName;
        private long creditCardNumber;

        //constructors
        Account(char[] username, char[] password, string emailAddress, char[] phoneNumber, string address, string firstName, string lastName, long creditCardNumber)
        {
            this.username = username;
            this.password = password;
            this.emailAddress = emailAddress;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.firstName = firstName;
            this.lastName = lastName;
            this.creditCardNumber = creditCardNumber;
        }
        Account()
        {

        }

        //Getters and Setters
        public char[] getUsername()
        {
            return this.username;
        }
        public char[] getPassword()
        {
            return this.password;
        }
        public string getEmailAddress()
        {
            return this.emailAddress;
        }
        public char[] getPhoneNumber()
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
        public long getCreditCardNumber()
        {
            return this.creditCardNumber;
        }
        //Methods
    }
}