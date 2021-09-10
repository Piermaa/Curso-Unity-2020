using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput, verticalInput;
    public float speed = 50f;
    public float xRange = 20.5f;
    public GameObject proyectilePrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput);
        if (transform.position.x < -xRange)
        { transform.position = new Vector3(-xRange, transform.position.y, transform.position.z); }
        if (transform.position.x > xRange)
        { transform.position = new Vector3(xRange, transform.position.y, transform.position.z); }
        transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(proyectilePrefab,
                transform.position,
                proyectilePrefab.transform.rotation);
        }

    }
}
  
 