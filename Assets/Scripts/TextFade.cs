using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFade : MonoBehaviour
{
    public GameObject text;
    public GameObject UI;
    
    void Awake()
    {
        text.SetActive(false);//invisible at first
    }
    // Start is called before the first frame update
    void Update()
    {
        if (GameObject.Find("KeyToMainRoom").GetComponent<getKey>().hasObtainedKey)
        {
            text.SetActive(true);
            Destroy(UI, 2.0f);
            //Debug.Log("obtained key: " + GameObject.Find("KeyToMainRoom").GetComponent<getKey>().hasObtainedKey);
            //text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
            //StartCoroutine(textDisappear());
            //StopCoroutine(textDisappear());
        }
    }
    //public IEnumerator textDisappear()
    //{
    //    text.SetActive(true);
    //    yield return new WaitForSeconds(2.0f);
    //    text.SetActive(false);
    //}
    //public IEnumerator FadeTextToFullAlpha()//alpha 0 -> 1
    //{
    //    text.color = new Color(text.color.r, text.color.g, text.color.b, 0);
    //    while(text.color.a < 1.0f)
    //    {
    //        text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a + (Time.deltaTime / 2.0f));
    //        yield return null;
    //    }
    //}
    //public IEnumerator FadeTextToZeroAlpha()//alpha 1 -> 0
    //{
    //    text.color = new Color(text.color.r, text.color.g, text.color.b, 1);
    //    while (text.color.a > 0.0f)
    //    {
    //        text.color = new Color(text.color.r, text.color.g, text.color.b, text.color.a - (Time.deltaTime / 2.0f));
    //        yield return null;
    //    }
    //}
    
}
