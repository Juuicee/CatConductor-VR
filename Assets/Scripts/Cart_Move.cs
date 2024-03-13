using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cart_Move : MonoBehaviour
{
    public Camera playerCamera;
    public float moveSpeed = 5f;
    public int maxLeftPositions = -1; // Set the maximum left positions
    public int maxRightPositions = 1; // Set the maximum right positions
    private int currentXPosition = 0; // Tracks the current position

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        // Moves the player forward continously
        transform.Translate(Vector3.forward * Time.deltaTime *  moveSpeed);

        // Move Left
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            StartCoroutine(CartSwitchLeft());

        }

        // Move Right
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            StartCoroutine(CartSwitchRight());
        }
        //Look into Coroutine for switching

    }

    IEnumerator CartSwitchLeft() 
    {
        if (currentXPosition > maxLeftPositions)
        {
                currentXPosition--;
                transform.Translate(Vector3.left * 4f); // Move left by 4 units
                Debug.Log("left");
                yield return new WaitForSeconds(.1f);
                //yield return null;
        }


    }

    IEnumerator CartSwitchRight()
    {

        if (currentXPosition < maxRightPositions)
        {
                currentXPosition++;
                transform.Translate(Vector3.right * 4f); // Move right by 4 units
                Debug.Log("right");
                yield return new WaitForSeconds(.1f);
                //yield return null;
        }
        
    }


}
