using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _playerSpeed;
    [SerializeField] private Vector2 _playerjumpSpeed;

    private Rigidbody2D _rb;
    private  PlayerInputAction _playerInput;
    private Vector2 _playerMove;

    private bool _isGround;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerInput = new PlayerInputAction();
        _playerInput.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 vector = new Vector3();
        vector.x = Input.GetAxis("Horizontal");

        if (_isGround == true)
        {
            if (_playerInput.Player.Jump.IsPressed())
            {
                _rb.AddForce(_playerjumpSpeed, ForceMode2D.Impulse);
                _isGround = false;
            }
        }

        transform.position += vector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _isGround = true;
        }
    }
}
