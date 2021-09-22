using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(Rigidbody))]

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public bool isOnGround = true;
    public float gravityMultiplier;
    public float jumpForce = 10;

    private bool _gameOver = false;
    public bool GameOver { get => _gameOver; }

    private Animator _animator;
    public ParticleSystem explosion;
    public ParticleSystem basura;
    float speed_Multiplier;
    public AudioClip jumpSound, crashsound;
    private AudioSource _audioSource;

   

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity = gravityMultiplier*new Vector3(0, -9.81f, 0);
        _animator = GetComponent<Animator>();
        _audioSource = GetComponent<AudioSource>();
       
    }

  
    void Update()
    {
        
       
        _animator.SetFloat("Speed Multiplier", speed_Multiplier);
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround &&!_gameOver)
        {
            playerRb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            isOnGround = false;
            _animator.SetTrigger("Jump_trig");
            basura.Stop();//desaparece el ratro si esta en el aire
            _audioSource.PlayOneShot(jumpSound,1);          
        }
        speed_Multiplier = 1 + Time.time / 7;

     
    }

    private void OnCollisionEnter(Collision other)
    {
       
        if (other.gameObject.CompareTag("spoi")) 
        { isOnGround = true;
            basura.Play(); //al estar en el piso se activa el rastro
                           }
        else if (other.gameObject.CompareTag("Obstacle")) 
        {
            _gameOver = true;
            Debug.Log("GameOver");
            _animator.SetBool("Death_b",true);
            _animator.SetInteger("DeathType_int", Random.Range(1, 3));
            explosion.Play();
            basura.Stop();//desaparece el ratro si muere
            _audioSource.PlayOneShot(crashsound, 1);
            Invoke("RestartGame", 1.6f);
        }

    }
    void RestartGame()
    {
        SceneManager.LoadScene("Prototype 3",LoadSceneMode.Single);
        speed_Multiplier = 1;

    }
}
