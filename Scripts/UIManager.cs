using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public PlayableDirector _director;
    private void Start()
    {
        _director = GetComponent<PlayableDirector>();
    }
    public void SkipCinematic()
    {
        _director.gameObject.SetActive(false);
    }
    public void EnableDirector()
    {
        _director.gameObject.SetActive(true);
    }
}


  

