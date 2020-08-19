using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footSteps : MonoBehaviour
{
    public float stepRate = 0.5f;
    public float stepCooldown;
    public AudioSource audioSource;
    public AudioClip footStep;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        stepCooldown -= Time.deltaTime;
        if((Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f)
            && stepCooldown < 0f)
        {
            audioSource.pitch = 1f + Random.Range(-0.2f, 0.2f);
            audioSource.PlayOneShot(footStep, 0.9f);
            stepCooldown = stepRate;
        }
    }
}
