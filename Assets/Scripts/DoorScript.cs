using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    public GameObject door;
    public AudioSource audioSource;
    public bool isInFrontOfDoor;
    public bool isDoorOpen;

    // Start is called before the first frame update
    void Start()
    {
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
    public void PlayAudio()//문 열릴때 소리
    {
        audioSource.pitch = 1;
        audioSource.Play();

    }
    public void PlayReverseAudio()//문 닫힐때 소리(역재생)
    {
        audioSource.pitch = -1;
        audioSource.loop = true;
        audioSource.Play();
        StartCoroutine(StopLoop());
    }

    public IEnumerator StopLoop()
    {
        yield return new WaitForSeconds(0.5f);
        audioSource.loop = false;
    }

    // Update is called once per frame
    Vector3 rotate = new Vector3(0f, 0f, 90f);
    void Update()
    {
        //플레이어가 문앞에 서있고, 문은 닫힌 상태이며, E키를 눌렀을 때
        if (Input.GetKeyDown(KeyCode.E) && isInFrontOfDoor && !isDoorOpen)
        {
            door.transform.Rotate(rotate, Space.Self);
            PlayAudio();
            isDoorOpen = true;
        }
        //플레이어가 문앞에 서있고, 문은 열린 상태이며, E키를 눌렀을 때
        else if (Input.GetKeyDown(KeyCode.E) && isInFrontOfDoor && isDoorOpen)
        {
            door.transform.Rotate(-rotate, Space.Self);
            PlayAudio();
            isDoorOpen = false;
        }
    }
}
