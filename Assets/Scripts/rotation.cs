using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotation : MonoBehaviour
{
    // Initial rotation speed
    private float rotationSpeed = 0.1f;

    // speed increase rate per second
    private float speedIncreaseRate = 0.1f;

    //rate of slowing down
    private float slowDownRate = 0.5f;

    // Minimum and maximum rotation speed
    private float minRotationSpeed = 0.01f;
    private float maxRotationSpeed = 5f;

    private bool isSlowingDown = false; //flag to check if isSlowingDown function is active
    private float slowDownTimer = 0f; //timer to track slow down duration
    private float maxSlowDownTime = 3f; //Maximum duration for slow down

    //Capture Speed Variable before activating SlowDownRotation method
    private float originalSpeed = 0.1f;
    private float rapidSpeedUpRate = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        /*if (!isSlowingDown)
        {
            SpeedUpRotation();
        }*/

        // Check for the Z key being pressed and not already slowing down
        if (Input.GetKeyDown(KeyCode.Z) && !isSlowingDown)
        {
            originalSpeed = rotationSpeed;
            isSlowingDown = true;
            slowDownTimer = 0f; // Reset the slow down timer
        }

        if (isSlowingDown)
        {
            SlowDownRotation();
            slowDownTimer += Time.deltaTime; // Update the slow down timer

            // Check if the slow down duration has exceeded the maximum allowed time
            if (slowDownTimer >= maxSlowDownTime || Input.GetKeyUp(KeyCode.Z))
            {
                isSlowingDown = false; // Deactivate slow down
                StartCoroutine(RapidSpeedUp());
            }
        }

        transform.Rotate(0f, rotationSpeed, 0f, Space.Self);
    }

    IEnumerator RapidSpeedUp()
    {
        while (rotationSpeed < originalSpeed)
        {
            rotationSpeed += rapidSpeedUpRate * Time.deltaTime;
            yield return null;
        }
    }

    // Slowly increase in speed at a slow rate over time in int
    //be able to slow down a set amount but not to zero
    //dummy
    public void SpeedUpRotation()
    {
        // Increase rotation speed
        rotationSpeed += speedIncreaseRate * Time.deltaTime;

        // maximum speed
        rotationSpeed = Mathf.Clamp(rotationSpeed, minRotationSpeed, maxRotationSpeed);
    }

    public void SlowDownRotation()
    {
        rotationSpeed -= slowDownRate * Time.deltaTime;
        rotationSpeed = Mathf.Max(rotationSpeed, minRotationSpeed);
    }


    //capture the speed, then slow it down, then after slow down timer has elapsed, rapidly build up back to original speed
}
