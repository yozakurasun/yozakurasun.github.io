using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public enum EnemyType
    {
        Needle,
        Shot,
        Devil,
    }
    [SerializeField] private EnemyType _enemyType;
    private string _enemyName;
    // Start is called before the first frame update
    void Start()
    {
        _enemyName = Enum.GetName(typeof(EnemyType), _enemyType);
    }

    // Update is called once per frame
    void Update()
    {
        if(_enemyName == "Needle")
        {
            Needle();
        }
        else if(_enemyName == "Shot")
        {
            Shot();
        }
        else if( _enemyName == "Devil")
        {
            Devil();
        }
    }

    private void Needle()
    {

    }

    private void Shot() 
    {
        
    }

    private void Devil()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            GameController.Instance.GameOver();
        }
    }
}
