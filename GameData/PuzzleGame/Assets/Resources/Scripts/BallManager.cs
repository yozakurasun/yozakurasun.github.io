using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.XR;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class BallManager : MonoBehaviour
{

    public enum Balltype
    {
        Ball1,
        Ball2,
        Ball3,
        Ball4,
        Ball5,
        Ball6,
    }
    [SerializeField] private Balltype balltype;
    private string _ballname;

    private static int _ballSerial = 0;
    private int _mySerial;
    private bool _isControll;

    private Rigidbody rb;

    private GameObject _doropper;

    private void Awake()
    {
        _mySerial = _ballSerial;
        _ballSerial++;
    }

    void Start()
    {
        _doropper = GameObject.Find("BallDoropper");
        _ballname = Enum.GetName(typeof(Balltype), balltype);
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        _isControll = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            UseGravity();
        }

        if(transform.position.y <= 8)
        {
            UseGravity();
        }
        if (_isControll == true)
        {
            transform.position = new Vector3(_doropper.transform.position.x , _doropper.transform.position.y, _doropper.transform.position.z);
        }

    }

    public void UseGravity()
    {
        rb.useGravity = true;
        _isControll = false;
        GameController.Instance.CheckOnTrigger();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out BallManager otherBalls))
        {
            if (collision.gameObject.CompareTag(_ballname))
            {
                if (_mySerial < otherBalls._mySerial)
                {
                    GameController.Instance.BallClassUp(_ballname, collision.transform.position);
                    Destroy(gameObject);
                    Destroy(collision.gameObject);
                }

            }
        }

    }
}
