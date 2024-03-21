using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawningObstacles : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform island;
    public List<Transform> spawnLocations = new List<Transform>();
    public List<GameObject> smallObstacle = new List<GameObject>();
    public List<GameObject> mediumObstacle = new List<GameObject>();
    public List<GameObject> bigObstacle = new List<GameObject>();

    //Chance for each event to happen out of 100
    // 1 = chance for a single track obstacle to spawn
    // 2 = chance for a double track obstacle to spawn
    // 3 = chance for box
    public List<int> eventsToSpawn = new List<int>();
    private int totalChance = 0;
    

    void Start()
    {
        foreach (Transform child in transform)
        {
            spawnLocations.Add(child.transform);
        }

        for(int i = 0; i < eventsToSpawn.Count; i++){
            totalChance += eventsToSpawn[i];
            eventsToSpawn[i] = totalChance;
            Debug.Log(eventsToSpawn[i]);
        }

        StartCoroutine(Spawner(2f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawner(float spawnTimer){

        yield return new WaitForSeconds(spawnTimer);
        SpawnEnemy();
        

    }

    void SpawnEnemy(){

        float spawnTimer = 0;
        int nextAction = Random.Range(0, totalChance);
        Debug.Log(nextAction);

        if(nextAction < eventsToSpawn[0]){

            int trackSpawn = Random.Range(0, 3);
            int rock = Random.Range(0, smallObstacle.Count);
            Instantiate(smallObstacle[rock], spawnLocations[trackSpawn].position, Quaternion.identity, island); 

            spawnTimer = Random.Range(.5f, 1.5f);

        }

        else if(nextAction < eventsToSpawn[1]){
            int trackSpawn = Random.Range(3, 5);
            int rock = Random.Range(0, mediumObstacle.Count);
            Instantiate(mediumObstacle[rock], spawnLocations[trackSpawn].position, Quaternion.identity, island);

            spawnTimer = Random.Range(1.5f, 3f);
        }

        else if(nextAction < eventsToSpawn[2]){
            Instantiate(bigObstacle[0], spawnLocations[5].position, Quaternion.identity, island);
            spawnTimer = Random.Range(2f, 4f);
        }


        
        StartCoroutine(Spawner(spawnTimer));
    }
}
