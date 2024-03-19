using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawningObstacles : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform island;
    public float spawnTimer;
    public List<Transform> spawnLocations = new List<Transform>();
    public List<GameObject> obstacle = new List<GameObject>();
    

    void Start()
    {
        foreach (Transform child in transform)
        {
            spawnLocations.Add(child.transform);
        }

        StartCoroutine(Spawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawner(){

        yield return new WaitForSeconds(spawnTimer);
        SpawnEnemy();
        spawnTimer = Random.Range(1.2f, 2.5f);
        StartCoroutine(Spawner());

    }

    void SpawnEnemy(){
        int trackSpawn = Random.Range(0, 5);
        //Spawn small rock on one track
        if(trackSpawn == 0 || trackSpawn == 2 || trackSpawn == 4){
            Instantiate(obstacle[0], spawnLocations[trackSpawn].position, Quaternion.identity, island); 
        }
        else if(trackSpawn == 1 || trackSpawn == 3){
            Instantiate(obstacle[1], spawnLocations[trackSpawn].position, Quaternion.identity, island);
        }
        

    }
}
