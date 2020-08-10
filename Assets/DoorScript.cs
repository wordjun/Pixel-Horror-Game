﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject door;
    public AudioSource audio;
    public bool isInFrontOfDoor;
    public bool isDoorOpen;
    // Start is called before the first frame update
    void Start()
    {
        door = GameObject.FindWithTag("Door");
        audio = GetComponent<AudioSource>();
        isInFrontOfDoor = false;
        isDoorOpen = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") //해당 위치에 들어온 물체가 "Player"태그를 갖고 있는 경우
            isInFrontOfDoor = true;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            isInFrontOfDoor = false;
    }

    // Update is called once per frame
    Vector3 rotate = new Vector3(0f, 0f, 90f);
    void Update()
    {
        //플레이어가 문앞에 서있고, 문은 닫힌 상태이며, E키를 눌렀을 때
        if (Input.GetKeyDown(KeyCode.E) && isInFrontOfDoor && !isDoorOpen)
        {
            door.transform.Rotate(rotate, Space.Self);
            audio.Play();
            isDoorOpen = true;
        }
        //플레이어가 문앞에 서있고, 문은 열린 상태이며, E키를 눌렀을 때
        else if (Input.GetKeyDown(KeyCode.E) && isInFrontOfDoor && isDoorOpen)
        {
            door.transform.Rotate(-rotate, Space.Self);
            audio.Play();
            isDoorOpen = false;
        }
    }
}