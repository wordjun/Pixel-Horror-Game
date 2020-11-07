using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFade : MonoBehaviour
{
    public Text text;
    void Awake()
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
    }
    // Start is called before the first frame update
    void Update()
    {
        if (GameObject.Find("KeyToMainRoom").GetComponent<getKey>().hasObtainedKey)
        {
            Debug.Log("obtained key: " + GameObject.Find("KeyToMainRoom").GetComponent<getKey>().hasObtainedKey);
            StartCoroutine(FadeTextToZeroAlpha());
        }
    }
    public IEnumerator FadeTextToFullAlpha()//alpha 0 -> 1
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
        while(text.color.a < 1.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / 2.0f));
            yield return null;
        }
    }
    public IEnumerator FadeTextToZeroAlpha()//alpha 1 -> 0
    {
        text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
        while (text.color.a > 0.0f)
        {
            text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / 2.0f));
            yield return null;
        }
    }
    
}
