using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class BallDoropper : MonoBehaviour
{
    private float _horizontal = 0;
    private float _vertical = 0;
    private Vector3 _velocity;
    private float _speed = 3f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _horizontal = Input.GetAxis("Horizontal");
        _vertical = Input.GetAxis("Vertical");
        _velocity = new Vector3(_horizontal, 0, _vertical).normalized;
        rb.velocity = _velocity * _speed;
    }
}
