using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager2 : MonoBehaviour

{
    public GameObject[] prefabsObjects;
    public int index;
    float startDelay = 2f, spawnInterval = 1.5f;
    private PlayerControllerX _playerController;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRa",startDelay,spawnInterval);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnRa()

    {
        Vector3 spawnPos = new Vector3(18,7,0);
        index = Random.Range(0, prefabsObjects.Length);

        if (index >= 0  && index < prefabsObjects.Length)
        {
            Instantiate(prefabsObjects[index], spawnPos , prefabsObjects[index].transform.rotation);
        }
    }

}
