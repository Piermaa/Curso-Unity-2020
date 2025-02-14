﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetX : MonoBehaviour
{
    private Rigidbody rb;
    private GameManagerX gameManagerX;
    public int pointValue;
    public GameObject rottenParticles;
    public GameObject explosionFx;
    //public TextMeshProUGUI explosionText;

    public float timeOnScreen = 1.0f;

    private float minValueX = -3.75f; // the x value of the center of the left-most square
    private float minValueY = -3.75f; // the y value of the center of the bottom-most square
    private float spaceBetweenSquares = 2.5f; // the distance between the centers of squares on the game board
    

    void Start()
    {
       

     
        gameManagerX = GameObject.Find("Game Manager").GetComponent<GameManagerX>();

        transform.position = RandomSpawnPosition(); 
        StartCoroutine(RemoveObjectRoutine()); // begin timer before target leaves screen

       
     
    }

    // When target is clicked, destroy it, update score, and generate explosion
    private void OnMouseDown()
    {
        if (gameManagerX.isGameActive)
        {
            Destroy(gameObject);
            gameManagerX.UpdateScore(pointValue);
            Explode();
            if (gameObject.CompareTag("Bad")) 
            { 
                gameManagerX.GameOver(); 
            }
            StartCoroutine(HideExplosionText());
        }
               
    }

    // Generate a random spawn position based on a random index from 0 to 3
    Vector3 RandomSpawnPosition()
    {
        float spawnPosX = minValueX + (RandomSquareIndex() * spaceBetweenSquares);
        float spawnPosY = minValueY + (RandomSquareIndex() * spaceBetweenSquares);

        Vector3 spawnPosition = new Vector3(spawnPosX, spawnPosY, 0);
        return spawnPosition;

    }

    // Generates random square index from 0 to 3, which determines which square the target will appear in
    int RandomSquareIndex ()
    {
        return Random.Range(0, 4);
    }


    // If target that is NOT the bad object collides with sensor, trigger game over
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);

        if (other.gameObject.CompareTag("Sensor") && !gameObject.CompareTag("Bad"))
        {
            gameManagerX.GameOver();
        } 

    }


    bool showText=false;
    // Display explosion particle at object's position
    public void Explode ()
    {
       
        Instantiate(explosionFx, transform.position, explosionFx.transform.rotation);
        
        
    }

    // After a delay, Moves the object behind background so it collides with the Sensor object
    IEnumerator RemoveObjectRoutine()
    {

        yield return new WaitForSeconds(timeOnScreen);
        if (!gameObject.CompareTag("Bad")) 
        { 
            Instantiate(rottenParticles, transform.position, rottenParticles.transform.rotation); 
        }
        yield return new WaitForSeconds(timeOnScreen / 3f);

        pointValue /= 2;

        yield return new WaitForSeconds(timeOnScreen);
        if (gameManagerX.isGameActive)
        {
            transform.Translate(Vector3.forward * 5, Space.World);
        
        }

    }
    IEnumerator HideExplosionText()
    {
        gameManagerX.explosionText.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.5f);
            gameManagerX.explosionText.gameObject.SetActive(false);

    }
}
