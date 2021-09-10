using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameEnding : MonoBehaviour
{
    public float fadeDuration = 1f;

    public float displayImageDuration = 1f;

    private bool isPlayerAtExit, isPlayerCaught;
    bool pauseGame;
    public bool gameOnPause;

    public GameObject player;

    public CanvasGroup exitBackgroundImageCanvasGroup;

    public CanvasGroup caughtBackgroundImageCanvasGroup;

    public AudioSource exitAudio, caughtAudio;

    public GameObject pauseScreen;

    private bool hasAudioPlayed;

    private float timer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            isPlayerAtExit = true;
        }
    }

    private void Update()
    {
        if (isPlayerAtExit)
        {
            EndLevel(exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if (isPlayerCaught)
        {
            EndLevel(caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
       pauseGame = Input.GetKeyDown(KeyCode.Escape);
        bool unpauseGame = Input.GetKeyDown(KeyCode.Q);

        if ((pauseGame) && gameOnPause == false)
        {
            gameOnPause = true;
            pauseScreen.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        else if ((pauseGame) && gameOnPause == true)
        {
            gameOnPause = false;
            pauseScreen.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
            
      
     
    }

 
    /// <summary>
    /// Lanza la imagen de fin de la partida
    /// </summary>
    /// <param name="imageCanvasGroup">Imagen de fin de partida correspondiente</param>
    void EndLevel(CanvasGroup imageCanvasGroup, bool doRestart,AudioSource audioSource)
    {
        if (!hasAudioPlayed)
        { 
            audioSource.Play();
            hasAudioPlayed = true;
        }

        timer += Time.deltaTime;
        imageCanvasGroup.alpha = Mathf.Clamp(timer / fadeDuration, 0, 1);

        if (timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                RestartGame();
            }
            else
            {
                ExitGame();
            }
        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void ExitGame()
    {
        Application.Quit();
    }

    public void CatchPlayer()
    {
        isPlayerCaught = true;
    }
}