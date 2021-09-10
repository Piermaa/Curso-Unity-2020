using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyX : MonoBehaviour
{
    public float speed=10;
    private Rigidbody enemyRb;
    private GameObject playerGoal;

    private SpawnManagerX _spawnManagerX;
    public float speedIncrement;
    

    // Start is called before the first frame update
    void Start()
    {
        _spawnManagerX = GameObject.Find("Spawn Manager").GetComponent<SpawnManagerX>(); //relacionar el SpawnManagerX con el EnemyX
        speedIncrement = _spawnManagerX.waveCount; //Asignarle valor a la variable en EnemyX en base a una de SpawnManagerX
        speed = speed + speedIncrement-2; // Aumentar la velocidad cada vez que aumenta a la oleada, -2 para corregir el valor determinado de waveCount y su waveCount++

        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.FindGameObjectWithTag("PlayerGoal");
    }

    // Update is called once per frame
    void Update()
    {
        // Set enemy direction towards player goal and move there
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed * Time.deltaTime);
       
        
    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        } 
        else if (other.gameObject.name == "Player Goal")
        {

            Destroy(gameObject);
            SceneManager.LoadScene("Challenge 4");
        }

    }

}
