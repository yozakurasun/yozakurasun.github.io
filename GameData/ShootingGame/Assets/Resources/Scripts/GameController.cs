using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;

public class GameController : SingletonMonoBehaviour<GameController>
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private int _score;

    [SerializeField] private Transform _enemyParent;
    [SerializeField] private GameObject[] _enemyObject;
    [SerializeField] private float _enemySpawnSpan = 1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _scoreText.text = "Score : " + $"{_score}";

        EnemySpawn();
    }

    public void AddScore(int enemyScore)
    {
        _score += enemyScore;
    }

    private void EnemySpawn()
    {
        _enemySpawnSpan -= Time.deltaTime;
        if (_enemySpawnSpan <= 0)
        {
            int enemyIndex = Random.Range(0, _enemyObject.Length);
            float enemySpwanPointY = Random.Range(-4, 4);
            Instantiate(_enemyObject[enemyIndex], new Vector2(10, enemySpwanPointY), Quaternion.identity,  _enemyParent);
            _enemySpawnSpan = Random.Range(0.8f, 1.2f);
        }
    } 
}
