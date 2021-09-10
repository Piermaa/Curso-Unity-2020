using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateSlider : MonoBehaviour
{
    Animator _animator;
    GameManagerX _gameManagerX;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _gameManagerX = FindObjectOfType<GameManagerX>();
    }

    private void Update()
    {
       if (_gameManagerX.isGameActive==true) { StartAnimation(); }
    }
    public void StartAnimation()
    {
        _animator.SetTrigger("SG");
        this.gameObject.SetActive(true);
    }   
}
