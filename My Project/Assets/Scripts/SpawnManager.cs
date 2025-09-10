using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] entityPrefabs;
    int rangeX = -300;
    int rangeY = -100;
    int rangeZ = 100;

    private float startDelay = 2;
    private float spawnInterval = 5.0f;

    public float minDistanceFromNextSpawn = 10.0f;
    private List<Vector3> previousSpawns = new();

    void Start()
    {
        InvokeRepeating("SpawnRandom", startDelay, spawnInterval);    //Begin spawning enemies after 2 seconds
    }
        
    void SpawnRandom()
    {
        int entityIndex = Random.Range(0, entityPrefabs.Length);       //Spawn different enemies randomly

        Vector3 spawnPos;

        int attempts = 0;
        do
        {
            spawnPos = new Vector3(rangeX, rangeY, Random.Range(-rangeZ, rangeZ));
            attempts++;
            if (attempts > 50) break;                  //break from possible infite loop
        }
        while (!isFarEnough(spawnPos));

        previousSpawns.Add(spawnPos);

        Instantiate(entityPrefabs[entityIndex], spawnPos, entityPrefabs[entityIndex].transform.rotation);    //Spawn enemies randomly in the map
    }
    
    bool isFarEnough(Vector3 pos)
    {
        foreach (Vector3 prev in previousSpawns)     //check position of every previous spawn
        {
            if (Vector3.Distance(prev, pos) < minDistanceFromNextSpawn)
            {
                return false;
            }
        }
        return true;
    }
}