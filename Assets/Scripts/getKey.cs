﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class getKey : MonoBehaviour
{
    public GameObject safe;
    public GameObject mainRoomKey;
    public GameObject player;
    public GameObject keyBox;
    public AudioSource gotKeySoundEffect;
    
    public bool isInFrontOfKey;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
            isInFrontOfKey = true;
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            isInFrontOfKey = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        //hiddenPlace = GetComponent<GameObject>();
        //mainRoomKey = GetComponent<GameObject>();
        //player = GetComponent<GameObject>();

        isInFrontOfKey = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        //플레이어가 key앞에 서있고, 금고가 inactive상태이며, 입력값으로 E를 눌렀을 때
        if (!safe.activeSelf && isInFrontOfKey && Input.GetKey(KeyCode.E))
        {
            gotKeySoundEffect.Play();
            //key는 keybox 에 담는다(keybox는 별개의 공간에 위치, 맵과 멀리떨어져있도록)
            mainRoomKey.transform.position = keyBox.transform.position;
            
        }
    }
}
