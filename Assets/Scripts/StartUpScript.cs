using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StartUpScript : MonoBehaviour
{

    void Start()
    {
        string[] lines =
        {
            /// FirstNameLastName -- Username//Password -- PhoneNumber -- CreditCard -- Email -- Address///
            "Mom Pizza -- MomPizza1//pizzatime2021$$ -- 17705551212 -- 0000 1111 2222 3333 -- MPizza@MNPpizza.com -- 680 Arnston Rd Suite 161, Marietta, GA 30060",
            "Pop Pizza -- PopPizza1//perfectpizza12>> -- 1770551212 -- 0000 1111 2222 3333 -- PPizza@MNPpizza.com -- 680 Arnston Rd Suite 161, Marietta, GA 30060",
            "Boberto Billy -- BertoBoss12//billybob45## -- 16787703425 -- 6011 8321 1247 6130 -- BBilly@MNPpizza.com -- 688 Arnston Rd Suite 161, Marietta, GA 30060"
        };

        File.WriteAllLinesAsync("LoginInformation.txt", lines);
    }
    public static void WriteString()
    {
        string path = Application.persistentDataPath + "/test.txt";
        //Write some text to the test.txt file
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine("Test");
        writer.Close();
        StreamReader reader = new StreamReader(path);
        //Print the text from the file
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }
    public static void ReadString()
    {
        string path = Application.persistentDataPath + "/test.txt";
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        Debug.Log(reader.ReadToEnd());
        reader.Close();
    }
}
