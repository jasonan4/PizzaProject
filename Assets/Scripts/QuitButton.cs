using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuitButton : MonoBehaviour
{
    protected Button self;
    // Start is called before the first frame update


    void Start()
    {

        self = GetComponent<Button>();
        self.onClick.AddListener(ActOnClick);
    }

    public void ActOnClick()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
              Application.Quit();
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
