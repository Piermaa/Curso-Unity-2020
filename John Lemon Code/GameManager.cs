using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private Button _button;
    private GameEnding _gameEnding;
    public int function;
    private UIManager _UIManager;


    // Start is called before the first frame update
    void Start()
    {
        _UIManager=GetComponent<UIManager>(); 
        _button = GetComponent<Button>();
        _gameEnding = FindObjectOfType<GameEnding>();
        if (function == 1)
        {
            _button.onClick.AddListener(_gameEnding.RestartGame);
            _button.onClick.AddListener(Timescaling);


        }
        if (function == 2)
        {
            _button.onClick.AddListener(_gameEnding.ExitGame);
        }
        if (function == 3)
        {
            _button.onClick.AddListener(_UIManager.SkipCinematic);
        }
    }
    void Timescaling()
    {
        ////Time.timeScale = 1;
    }
  
}
