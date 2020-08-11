using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setActive : MonoBehaviour
{
    public GameObject openSafe = null;
    public bool isInFrontOfSafe;
    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            openSafe.SetActive(true);
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
            openSafe.SetActive(false);
            if (isInFrontOfSafe)
            {
                isInFrontOfSafe = false;
            }
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        openSafe.SetActive(false);
        isInFrontOfSafe = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
