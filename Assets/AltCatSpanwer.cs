using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AltCatSpawner : MonoBehaviour
{
    public Transform seatTransform;
    public float spawnThreshholdDistance = 1f;
    private bool canSpawn = true;




    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.S))
        {
            ForceSpawn();
        }

        if (canSpawn && Vector3.Distance(transform.position, seatTransform.position) > spawnThreshholdDistance)
        {
            canSpawn = false;
        }
    }

    void SpawnCat()
    {
        //spawns a new cat on top of the current one
        Vector3 spawnPosition = transform.position + new Vector3(0, 1, 0);

        GameObject newCat = Instantiate(gameObject, spawnPosition, Quaternion.identity);

        newCat.transform.parent = null;

        /*Prevent respawning
        var catSpawner = newCat.GetComponent<CatSpawner>();
        if (catSpawner != null)
        {
            catSpawner.canSpawn = false;
        }*/
    }

    void ForceSpawn()
    {
        SpawnCat();
    }
}
