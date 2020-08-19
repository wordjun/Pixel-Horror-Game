using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quizUI : MonoBehaviour
{
    public GameObject livingRoomQuizUI;
    public GameObject guideToPaper;
    public GameObject guideToExit;
    public bool isInFrontOfPaper;
    public bool isUIOpen;
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            isInFrontOfPaper = true;
            guideToPaper.SetActive(true);
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            isInFrontOfPaper = false;
            guideToPaper.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        livingRoomQuizUI.SetActive(false);
        guideToPaper.SetActive(false);
        guideToExit.SetActive(false);
        isInFrontOfPaper = false;
        isUIOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isInFrontOfPaper && !isUIOpen&& Input.GetKeyDown(KeyCode.E))
        {
            livingRoomQuizUI.SetActive(true);
            guideToPaper.SetActive(false);
            guideToExit.SetActive(true);
            isUIOpen = true;
        }
        else if(isInFrontOfPaper && isUIOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            livingRoomQuizUI.SetActive(false);
            guideToPaper.SetActive(true);
            guideToExit.SetActive(false);
            isUIOpen = false;
        }
    }
}
