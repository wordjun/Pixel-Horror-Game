using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PushButton : MonoBehaviour
{
    public GameObject outputScreen;
    public Text outputText;
    public string inputString;
    public GameObject safe;
    public GameObject keypadUI;
    public GameObject wrongNumUI;
    public AudioSource incorrectBeep;
    public AudioSource buttonPressSound;
    public AudioSource openSafeSound;

    public void appendText(int num)
    {
        buttonPressSound.Play();
        inputString = num.ToString();
        outputText.text += inputString;
    }
    public void clearText()
    {
        buttonPressSound.Play();
        outputText.text = "";
    }
    

    public void checkPasswd()
    {
        if(outputText.text == "4371")//correct pin num
        {
            openSafeSound.PlayOneShot(openSafeSound.clip);

            safe.SetActive(false);

            if (wrongNumUI.activeSelf)
                wrongNumUI.SetActive(false);
        }
        else//incorrect pin num
        {
            incorrectBeep.Play();
            wrongNumUI.SetActive(true);
            clearText();
        }
    }

    void Start()
    {
        //outputScreen = GetComponent<GameObject>();
        //outputText = outputScreen.GetComponent<Text>();
        //hiddenPlace = GetComponent<GameObject>();
        //keypadUI = GetComponent<GameObject>();
        wrongNumUI.SetActive(false);
    }
    void Update()
    {
        if (safe.activeSelf)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
