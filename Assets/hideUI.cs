using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideUI : MonoBehaviour
{
    
    public CanvasGroup canvasGroup;
    public GameObject safe;

    public void hideUi()
    {
        canvasGroup.alpha = 0f;//makes everything transparent
        canvasGroup.blocksRaycasts = false;//prevents the UI element to receive input events
    }
    public void showUI()
    {
        canvasGroup.alpha = 1f;//makes everything visible
        canvasGroup.blocksRaycasts = true;//lets the UI element to receive input events
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!safe.activeSelf)
            hideUi();
    }
}
