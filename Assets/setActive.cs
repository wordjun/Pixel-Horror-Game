using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class setActive : MonoBehaviour
{
    public GameObject guideToSafe = null;
    public GameObject keyPad = null;
    public bool isKeyPadUIOpen;
    public bool isInFrontOfSafe;
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            guideToSafe.SetActive(true);//show "press E"
            if (!isInFrontOfSafe)
            {
                isInFrontOfSafe = true;
            }
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            guideToSafe.SetActive(false);//do not show "press E"
            if (isInFrontOfSafe)
            {
                isInFrontOfSafe = false;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        guideToSafe.SetActive(false);
        keyPad.SetActive(false);
        isInFrontOfSafe = false;
        isKeyPadUIOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isInFrontOfSafe && Input.GetKeyDown(KeyCode.E) && !isKeyPadUIOpen)
        {
            //while inside the keypad UI, player's movement and view must be stopped temporarily(pause game process)
            keyPad.SetActive(true);//show keypad UI
            guideToSafe.SetActive(false);//disable the guide text to open keypad UI
            isKeyPadUIOpen = true;
            Cursor.lockState = CursorLockMode.Locked;
        }
        else if(isInFrontOfSafe && Input.GetKeyDown(KeyCode.Escape) && isKeyPadUIOpen)
        {
            //while inside the keypad UI, pressing esc will let the player resume back to game
            keyPad.SetActive(false);
            isKeyPadUIOpen = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
