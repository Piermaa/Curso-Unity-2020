using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;
    public bool onGameLimits;

    public float floatForce=35f;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;
    float timecd;
    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;
    
    private AudioSource _audioSource;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip jumpSound;

    public Animator _animator;
 


    // Start is called before the first frame update
    void Start()
    {
        
        _audioSource = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();
  
        Physics.gravity *= gravityModifier;

        _animator = GetComponent<Animator>();


        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 10, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()

    {
        if (transform.position.y < 10) { onGameLimits = true; }
        if (transform.position.y > 10) { onGameLimits = false; }
     
        // While space is pressed and player is low enough, float up
        if (Input.GetKeyDown(KeyCode.Space) && !gameOver && onGameLimits )
        {
            playerRb.AddForce(Vector3.up * floatForce , ForceMode.Impulse);
            _audioSource.PlayOneShot(jumpSound, 1f);
            Debug.Log("Salto");
       
            
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            _audioSource.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
            _animator.SetBool("Dead",true);
            
            

           
        }

        // if player collides with money, fireworks

        if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            _audioSource.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);
        }
        

     

    }
    void ExplotaGlobo()
    { Destroy(gameObject); }
}
