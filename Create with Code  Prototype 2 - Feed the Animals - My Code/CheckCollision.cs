using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Proyectile"))
        {
            Destroy(gameObject);
            Destroy(other.gameObject); 
        }
    }
}
