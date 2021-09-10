using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
   
    public float moveForce;
    GameObject player;
    private Rigidbody _rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()

    {
        if (transform.position.y>-1) 
        {
            Vector3 direction = player.transform.position - this.transform.position;
            _rigidbody.AddForce(moveForce * direction);
        }
  
        if(transform.position.y < -5)
        { 
            Destroy(this.gameObject);
        }

    }
}
