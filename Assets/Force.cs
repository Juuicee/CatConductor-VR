using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Force : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<Rigidbody>().AddForce(transform.up * 500);
            GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
