using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : SingletonMonoBehaviour<GameController>
{
    [SerializeField] private GameObject _gameOverObject;
    [SerializeField] private GameObject _gameClearObject;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        _gameOverObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void GameClear()
    {
        _gameClearObject.SetActive(true);
        Time.timeScale = 0f;
    }
}
