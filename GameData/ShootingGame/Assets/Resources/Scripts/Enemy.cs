using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;

    public enum EnemyType
    {
        Enemy0,
        Enemy1,

    }
    [SerializeField] private EnemyType _enemyType;
    private string _enemyName;

    [SerializeField] private int _enemyScore = 1;
    [SerializeField] private int _enemyHelth = 1;
    [SerializeField] private float _enemySpeed = 1f;

    private int _hitIndex = 0;

    void Start()
    {
        _enemyName = Enum.GetName(typeof(EnemyType), _enemyType);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(-_enemySpeed, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            _hitIndex++;
            Destroy(collision.gameObject);

            if (_enemyName == "Enemy0")
            {
                if(_hitIndex == _enemyHelth)
                {
                    GameController.Instance.AddScore(_enemyScore);
                    Destroy(this.gameObject);
                }
            }
            else if (_enemyName == "Enemy1")
            {
                if (_hitIndex == _enemyHelth)
                {
                    GameController.Instance.AddScore(_enemyScore);
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
