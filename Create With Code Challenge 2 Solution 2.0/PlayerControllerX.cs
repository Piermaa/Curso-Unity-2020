using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float counter;
    private float cooldown = 0.3f;
    

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;

        if (counter>=cooldown) 
        {


            // On spacebar press, send dog
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
                counter = 0;
            }
            
        }
    }
}
