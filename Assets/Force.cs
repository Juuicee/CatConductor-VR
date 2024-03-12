using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{
    Vector3 ImpulseVector = new Vector3(6.0f, 6.0f, 0.0f);
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("hello");
            GetComponent<Rigidbody>().AddForce(ImpulseVector, ForceMode.Force);
            GetComponent<Rigidbody>().useGravity = true; 
        }
    }
}
