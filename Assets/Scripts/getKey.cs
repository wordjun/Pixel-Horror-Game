using System;
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
    public GameObject keypadUI;
    public GameObject guideToKey;
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
        guideToKey.SetActive(false);
        isInFrontOfKey = false;
    }
    
    // Update is called once per frame
    void Update()
    {
        //금고가 inactive상태이며, 플레이어가 key앞에 서있을때
        if (!safe.activeSelf && isInFrontOfKey )
        {
            //key획득 UI
            guideToKey.SetActive(true);
            if (Input.GetKey(KeyCode.E)) //입력값으로 E를 눌렀을 때
            {
                guideToKey.SetActive(false);
                gotKeySoundEffect.Play();//열쇠 획득 효과음 재생
                                         //key는 keybox 에 담는다(keybox는 별개의 공간에 위치, 맵과 멀리떨어져있도록)
                mainRoomKey.transform.position = keyBox.transform.position;
                //player가 key를 소지하게 됨
                arrayOfKeys.hasKeys[1] = true;//1번째 인덱스(두번째 키)는 안방으로 향하는 문의 열쇠
                                              //Debug.Log("Obtained Key to Main Room.");
                                              //for(int i = 0; i < 5; i++)
                                              //{
                                              //    if(arrayOfKeys.hasKeys[i])
                                              //        Debug.Log("key number " + (i + 1) + "obtained");
                                              //    else
                                              //        Debug.Log("key number " + (i + 1) + "not obtained yet");
                                              //}

                Cursor.visible = false;//UI가 꺼지고 나서 마우스도 비활성화
            }
        }
        else
        {
            guideToKey.SetActive(false);
        }
    }
}
