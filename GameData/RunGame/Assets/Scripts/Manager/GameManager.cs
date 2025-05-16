using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : SingletonMonoBehaviour<GameManager>
{

    [SerializeField] private GameObject[] _stages;
    [SerializeField] private Transform _stageParent;
    private int _stageIndex;

    private void Start()
    {
        SpawnRandamStage();
    }

    public void SpawnRandamStage()
    {
       _stageIndex = Random.Range(0, _stages.Length);
        Instantiate(_stages[_stageIndex], new Vector3(20.0f, -5.0f, 0.0f), Quaternion.identity, _stageParent);
    }

    public void GameOver(bool isGameOver)
    {
       if (isGameOver)
       {
           Time.timeScale = 0;
       }
    }

}
