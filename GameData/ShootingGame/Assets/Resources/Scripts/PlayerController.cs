using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using static Bullet;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    private float _horizontal;
    private float _vertical;
    [SerializeField] private float _pleyerSpeed;
    [SerializeField] private Transform _muzzlePosition;
    [SerializeField] private GameObject[] _bulletPrefabs;
    [SerializeField] private enum BattleType
    {
        Type0,
        Type1,
    }
    [SerializeField] private BattleType _myBattleType;

    private int _myBattleTypeValue;

    private Vector2 _velocity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    { 
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");

        _velocity = new Vector2(_horizontal, _vertical);
        rb.velocity = _velocity * _pleyerSpeed;

        ShotBullet();
    }

    private void ShotBullet()
    {
        if (Input.GetMouseButtonDown(0))
        {//“s“x’Ç‰Á—\’è
            switch (_myBattleType)
            {
                case BattleType.Type0:
                    Instantiate(_bulletPrefabs[0], _muzzlePosition.position, Quaternion.identity, _muzzlePosition);
                    break;
                case BattleType.Type1:
                    Instantiate(_bulletPrefabs[1], _muzzlePosition.position, Quaternion.identity, _muzzlePosition);
                    break;

            }
            
        }
    }
}
