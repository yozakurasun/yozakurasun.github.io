using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;

    public enum BulletType
    {
        Bullet0 = 0,
        Bullet1 = 1,

    }
    [SerializeField] private BulletType _bulletType;

    private string _bulletName;

    [SerializeField] private float _bulletSpeed0;

    // Start is called before the first frame update
    void Start()
    {
        _bulletName = Enum.GetName(typeof(BulletType), _bulletType);
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(_bulletName == "Bullet0")
        {
            BulletMove0();
        }
        else if(_bulletName == "Bullet1")
        {
            BulletMove1();
        }
    }


    private void BulletMove0()
    {
        rb.velocity = new Vector2(_bulletSpeed0, 0);
    }

    private void BulletMove1()
    {
        rb.velocity = new Vector2(_bulletSpeed0, 0);
    }

}
