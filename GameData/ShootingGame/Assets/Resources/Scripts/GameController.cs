using TMPro;
using UnityEngine;

public class GameController : SingletonMonoBehaviour<GameController>
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    private int _score;

    [SerializeField] private Transform _enemyParent;
    [SerializeField] private GameObject[] _enemyObject;
    [SerializeField] private float _enemySpawnSpan = 1f;
    [SerializeField] private GameObject _gameOverObject;
    [SerializeField] private GameObject _explosionObject;
    [SerializeField] private GameObject _hitEffectObject;
    [SerializeField] private Transform _hitParent;
    private float _waitTime = 1f;
    private bool _isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _scoreText.text = "Score : " + $"{_score}";

        if (_waitTime >= -1f && _isGameOver == true) 
        {
            _waitTime -= Time.deltaTime;
        }

        if (_waitTime <= 0)
        {
            _gameOverObject.SetActive(true);
            Time.timeScale = 0;
        }

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

    public void HitEffect(Vector3 hitPosition)
    {
        Instantiate(_hitEffectObject, hitPosition, Quaternion.identity, _hitParent);
    }

    public void GameOver(Vector3 hitPosition)
    {
        _isGameOver = true;
        _explosionObject.transform.position = hitPosition;
        _explosionObject.SetActive(true);
    }
}
