using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PushButton : MonoBehaviour
{
    public GameObject outputScreen;
    public Text outputText;
    public string inputString;

    public void appendText(int num)
    {
        inputString = num.ToString();
        outputText.text += inputString;
    }
    public void clearText()
    {
        outputText.text = "";
    }
    public void checkPasswd()
    {
    }

    void Start()
    {
        outputScreen = GetComponent<GameObject>();
        outputText = outputScreen.GetComponent<Text>();
    }
    void Update()
    {
        
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }
}
