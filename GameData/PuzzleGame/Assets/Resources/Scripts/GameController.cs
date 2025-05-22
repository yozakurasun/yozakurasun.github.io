using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameController : SingletonMonoBehaviour<GameController>
{
    [SerializeField] private GameObject[] _balls;
    [SerializeField] private Transform _ballParent;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private GameObject _naviGate;

    private int _randIndex;
    private bool _isCheck;

    private int _score;

    // Start is called before the first frame update
    void Start()
    {
        SpawnNewBall();
        _naviGate.SetActive(true);
        _isCheck = false;
    }

    // Update is called once per frame
    void Update()
    {
        _scoreText.text = "Score : " + $"{_score}";
    }

    public void SpawnNewBall()
    {
        _randIndex = Random.Range(0, _balls.Length - 3);
        Instantiate(_balls[_randIndex], _ballParent);
    }

    public void BallClassUp(string ballName, Vector3 conflictPosition)
    {
        if(ballName == "Ball1")
        {
            Instantiate(_balls[1], conflictPosition, Quaternion.identity, _ballParent);
            _score += 1;
        }
        else if (ballName == "Ball2")
        {
            Instantiate(_balls[2], conflictPosition, Quaternion.identity, _ballParent);
            _score += 3;
        }
        else if (ballName == "Ball3")
        {
            Instantiate(_balls[3], conflictPosition, Quaternion.identity, _ballParent);
            _score += 7;
        }
        else if (ballName == "Ball4")
        {
            Instantiate(_balls[4], conflictPosition, Quaternion.identity, _ballParent);
            _score += 13;

        }
        else if (ballName == "Ball5")
        {
            Instantiate(_balls[5], conflictPosition, Quaternion.identity, _ballParent);
            _score += 21;
        }
        else if (ballName == "Ball6")
        {
            _score += 31;
        }
    }

    public void CheckOnTrigger()
    {
        _isCheck = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isCheck == true)
        {
            if (other.gameObject.layer == LayerMask.NameToLayer("balls"))
            {
                SpawnNewBall();
                _isCheck = false;
            }
        }
    }
}
