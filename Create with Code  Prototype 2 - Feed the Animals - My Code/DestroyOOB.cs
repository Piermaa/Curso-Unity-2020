using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOOB : MonoBehaviour
{

    private float zbound = 40f, xbound = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((transform.position.z < -zbound) ||
                (transform.position.z > zbound))
         { 
            Destroy(gameObject); 
        }


        if ((transform.position.x > xbound) || (transform.position.x > xbound))
        {
            Destroy(gameObject);
        }
        
    }
}
