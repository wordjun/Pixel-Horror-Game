using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightControl : MonoBehaviour
{
    private Light myLight;
    public AudioSource torchClick;
    // Start is called before the first frame update
    void Start()
    {
        myLight = GetComponent<Light>();
        myLight.enabled = false;//flashlight is off at start
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (myLight.enabled == false)
                myLight.enabled = true;
            else
                myLight.enabled = false;

            torchClick.Play();
        }
    }
}
