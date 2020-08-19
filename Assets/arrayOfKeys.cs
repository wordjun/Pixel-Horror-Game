using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arrayOfKeys : MonoBehaviour
{
    public GameObject[] keys;
    public bool[] hasKeys;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //첫번째 key 획득 시(획득했다면 해당 key오브젝트가 inactive
        if (!keys[0].activeSelf)
        {
            hasKeys[0] = true;
            
        }
    }
}
