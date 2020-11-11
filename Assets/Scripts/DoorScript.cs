using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorScript : MonoBehaviour
{
    public GameObject door;
    public AudioSource doorOpenSound;
    public AudioSource doorLockedSound;
    public GameObject needKeyUI;
    public bool isInFrontOfDoor;
    public bool isDoorOpen;

    // Start is called before the first frame update
    void Start()
    {
        isInFrontOfDoor = false;
        isDoorOpen = false;
        needKeyUI.SetActive(false);
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
    public void PlayDoorOpenAudio()//문 열릴때 소리
    {
        doorOpenSound.pitch = 1;
        doorOpenSound.Play();

    }
    public void PlayDoorLockedAudio()
    {
        doorLockedSound.Play();
    }
    public void PlayReverseAudio()//문 닫힐때 소리(역재생)
    {
        doorOpenSound.pitch = -1;
        doorOpenSound.loop = true;
        doorOpenSound.Play();
        StartCoroutine(StopLoop());
    }

    public IEnumerator StopLoop()
    {
        yield return new WaitForSeconds(0.5f);
        doorOpenSound.loop = false;
    }

    // Update is called once per frame
    Vector3 rotate = new Vector3(0f, 0f, 90f);
    void Update()
    {
        //플레이어가 문앞에 서있고, 문은 닫힌 상태이고, E키를 눌렀으며 key를 갖고 있는 경우
        if (Input.GetKeyDown(KeyCode.E) && isInFrontOfDoor && !isDoorOpen &&
            arrayOfKeys.hasKeys[1])
        {
            door.transform.Rotate(rotate, Space.Self);
            PlayDoorOpenAudio();
            isDoorOpen = true;
            needKeyUI.SetActive(false);
        }
        //플레이어가 문앞에 서있고, 문은 열린 상태이며, E키를 눌렀을 때
        else if (Input.GetKeyDown(KeyCode.E) && isInFrontOfDoor && isDoorOpen)
        {
            door.transform.Rotate(-rotate, Space.Self);
            PlayDoorOpenAudio();
            isDoorOpen = false;
            needKeyUI.SetActive(false);
        }//앞에 서있고 문은 열리지 않은 상태에서 열쇠없이 E를 눌렀을 때
        else if(Input.GetKeyDown(KeyCode.E) && isInFrontOfDoor && !isDoorOpen &&
            !arrayOfKeys.hasKeys[1])
        {
            PlayDoorLockedAudio();
            needKeyUI.SetActive(true);
        }

        if (!isInFrontOfDoor && needKeyUI.activeSelf)
        {
            needKeyUI.SetActive(false);
        }
    }
}
