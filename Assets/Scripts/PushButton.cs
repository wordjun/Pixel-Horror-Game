using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PushButton : MonoBehaviour
{
    public Text outputScreen;
    
    public void setText(string text)
    {
        outputScreen.text = outputScreen.text + text;
    }

    void Start()
    {
        outputScreen = GetComponent<Text>();
    }
}
