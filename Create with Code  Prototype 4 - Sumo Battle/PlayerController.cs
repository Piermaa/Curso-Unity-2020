using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerController : MonoBehaviour
 
{
    private Rigidbody _rigidbody;
    public float moveForce;
    public GameObject focalPoint;
    public bool pickedPowerUp;
    public GameObject[] powerUpIndicators;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
   
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        _rigidbody.AddForce(focalPoint.transform.forward * moveForce*forwardInput);
        foreach (GameObject indicator in powerUpIndicators) 
        {
            indicator.transform.position = this.transform.position;
        }

        if (transform.position.y<-10) { SceneManager.LoadScene("Prototype 4"); }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUP")) 
        {
            pickedPowerUp=true;
            Destroy(other.gameObject);
            StartCoroutine(PowerUpCountdown());
            
          
        }
    }
    private void OnCollisionEnter(Collision collision) 
    {
        if (collision.gameObject.CompareTag("Enemy") && pickedPowerUp)

        { 
           Destroy(collision.gameObject); 
        }
        
    }
    IEnumerator PowerUpCountdown()
    {
            foreach (GameObject indicator in powerUpIndicators)
            {
                indicator.gameObject.SetActive(true);
                yield return new WaitForSeconds(2);
                indicator.gameObject.SetActive(false);

            }
        
        pickedPowerUp = false;
    }

    


}

