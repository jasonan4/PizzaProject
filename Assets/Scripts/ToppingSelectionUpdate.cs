using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToppingSelectionUpdate : MonoBehaviour
{
    ToggleGroup toggletest;
    public Toggle selected;
    // Start is called before the first frame update
    void Start()
    {
        toggletest = GetComponent<ToggleGroup>();
        List<Toggle> testing = new List<Toggle>();
        

    }
    public Toggle theOneThatIsSelected()
    {
        var list = toggletest.GetComponentsInChildren<Toggle>();
        
        foreach (Toggle element in list)
        {
            if (element.isOn == true)
            {
                selected = element;
                break;
            }
        }
        return selected;
    }
    void Update()
    {
        selected = theOneThatIsSelected();
    }

}
