using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupPlates : MonoBehaviour
{
    //UI that says "pick up the plate"
    public GameObject pickupPlateUI;
    public GameObject plate;
    public GameObject HUD;
    public AudioSource pickupSound;

    public bool isInFrontOfPlate;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            isInFrontOfPlate = true;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            isInFrontOfPlate = false;
    }
    void Start()
    {
        pickupPlateUI.SetActive(false);
        isInFrontOfPlate = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInFrontOfPlate)
        {
            pickupPlateUI.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                pickupSound.Play();
                plate.SetActive(false);//E키를 눌러 주우면 접시는 사라짐
                //아이템창에 뜸
            }
        }
        else
        {
            pickupPlateUI.SetActive(false);
        }
    }
}
