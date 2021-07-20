using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private int index;
    private int randomSpawnPos;
    private float spawnPos = 10;
    public int enemyCount;
    public int enemyWave;
    public GameObject powerUp;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        index = Random.Range(0, enemyPrefabs.Length);
        randomSpawnPos = Random.Range(-10, 10);
        enemyCount = GameObject.FindObjectsOfType<Enemy>().Length;
        
        
        if(enemyCount==0)
        {
            Instantiate(powerUp, GenerateRandomPosition(), transform.rotation);
            enemyWave++;
            SpawnEnemyWave(enemyWave);
            
        }
    }

    private Vector3 GenerateRandomPosition()
    {
        float spawnPosX = Random.Range(-spawnPos, spawnPos);
        float spawnPosZ =Random.Range(-spawnPos,spawnPos);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    /// <summary>
    /// Método que genera un numero determinado de enemigos en pantalla
    /// </summary>
    
    private void SpawnEnemyWave(int numberOfEnemies)
    {
        Instantiate(enemyPrefabs[index], 
            GenerateRandomPosition(), 
            enemyPrefabs[index].transform.rotation);
    }


}
