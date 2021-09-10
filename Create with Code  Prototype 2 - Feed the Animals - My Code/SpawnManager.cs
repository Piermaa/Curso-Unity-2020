using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies;
    public int animalIndex;
    
    private float spawnRangeX = 20f;
   
    private float spawnPosZ;
    private float startDelay = 2f;
    private float spawnInterval = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        spawnPosZ = transform.position.z;
        InvokeRepeating("SpawnRA", startDelay, spawnInterval);
    }


    private void SpawnRA()
    {
        float xRand = Random.Range(-spawnRangeX, spawnRangeX);

        Vector3 spawnPos = new Vector3(xRand, 0, spawnPosZ);

        animalIndex = Random.Range(0, enemies.Length);

        Instantiate(enemies[animalIndex],
            spawnPos,
            enemies[animalIndex].transform.rotation);
    }
}
