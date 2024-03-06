using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart_Move : MonoBehaviour
{
    public Camera playerCamera;
    public float moveSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Moves Forward and back along z axis                           //Up/Down
        //transform.Translate(Vector3.forward * Time.deltaTime * Input.GetAxis("Vertical")* moveSpeed);
        //Moves Left and right along x Axis                               //Left/Right
        transform.Translate(Vector3.forward * Time.deltaTime *  moveSpeed);

        // Move Left
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);

        }

        // Move Right
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
        }
        //Look into Coroutine for switching
    }
}
