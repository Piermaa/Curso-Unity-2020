﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftX : MonoBehaviour
{
    public float speed;
    private PlayerControllerX _playerController;
    private float leftBound = -10;

    // Start is called before the first frame update
    void Start()
    {
        _playerController = GameObject.Find("Player").GetComponent<PlayerControllerX>();
    }

    // Update is called once per frame
    void Update()
    {
        // If game is not over, move to the left
        if (!_playerController.gameOver)
        {
            transform.localPosition+=Vector3.left * speed *Time.deltaTime;
        }

        // If object goes off screen that is NOT the background, destroy it
        if (transform.position.x < leftBound && !gameObject.CompareTag("Background"))
        {
            Destroy(gameObject);
        }

    }
}
