using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] entityPrefabs;
    int rangeX = -40;
    int rangeY = 12;
    int rangeZ = 50;

    private float startDelay = 2;
    private float spawnInterval = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandom", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {

    }
        
    void SpawnRandom()
    {
        int entityIndex = Random.Range(0, entityPrefabs.Length);

        Vector3 spawnPos = new Vector3(rangeX, rangeY, Random.Range(-rangeZ, rangeZ));
        Instantiate(entityPrefabs[entityIndex], spawnPos, entityPrefabs[entityIndex].transform.rotation);
    }
}
