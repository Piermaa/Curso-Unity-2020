using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval = 2.5f;
    public int pelotarandom;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {

        // Generate random ball index and random spawn position
        
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
        
        //Elegir una pelota de forma aleatoria
        pelotarandom = Random.Range(0, ballPrefabs.Length);
        
        // instantiate ball at random spawn location
        
        Instantiate(ballPrefabs[pelotarandom], spawnPos, ballPrefabs[pelotarandom].transform.rotation);
    }
    private float counter;
    private float nexW8Time = 5;
    private void Update()
    {
        counter += Time.deltaTime;
        if (counter >= nexW8Time) 
        {
            Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);
            Debug.LogFormat("Pasaron {0} segundos", nexW8Time);
            Instantiate(ballPrefabs[pelotarandom], spawnPos, ballPrefabs[pelotarandom].transform.rotation);
            counter = 0;
            nexW8Time = Random.Range(1,4);

        }
    }

}
