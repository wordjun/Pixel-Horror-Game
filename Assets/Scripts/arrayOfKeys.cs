using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrayOfKeys : MonoBehaviour
{
    public static bool[] hasKeys;
    
    // Start is called before the first frame update
    void Awake()
    {
        hasKeys = new bool[5];//맵의 키는 총 5개
    }

}
