using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bumpsounds : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audio;
    public float hitspeed = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > hitspeed)
        {
            audio.Play();
        }
        
    }
}
