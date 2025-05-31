using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : SingletonMonoBehaviour<PlayerController>
{
    [SerializeField] private float _playerSpeed;
    [SerializeField] private Vector2 _playerjumpSpeed;

    private Rigidbody2D _rb;
    private Animator _anim;
    private  PlayerInputAction _playerInput;
    private Vector2 _inputDirection;
    private Vector2 _playerMove;

    private bool _isGround;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _playerInput = new PlayerInputAction();
        _playerInput.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        if (_playerInput.Player.Jump.IsPressed())
        {
            jump(false);
        }

        Move();
        PlayerDirection();
    }

    private void PlayerDirection()
    {
        if(_inputDirection.x > 0.0f)
        {
            transform.eulerAngles = Vector3.zero;
        }
        else if(_inputDirection.x < 0.0f)
        {
             transform.eulerAngles = new Vector3(0, 180.0f, 0);
        }
    }

    public void jump(bool isForceJump)
    {
        if ( _isGround == true || isForceJump == true)
        {
            _rb.AddForce(_playerjumpSpeed, ForceMode2D.Impulse);
            _anim.SetBool("IsJump", true);
            _isGround = false;
        }
    }

    private void Move()
    {
        _rb.velocity = new Vector2(_inputDirection.x * _playerSpeed, _rb.velocity.y);       
    }

    public void _OnMove(InputAction.CallbackContext context)
    {
        _inputDirection = context.ReadValue<Vector2>();
        _anim.SetBool("IsWalk", _inputDirection.x != 0.0f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            _anim.SetBool("IsJump", false);
            _isGround = true;
        }

        if (collision.gameObject.CompareTag("Goal"))
        {
            GameController.Instance.GameClear();
        }

        if (collision.gameObject.CompareTag("DeadLine"))
        {
            GameController.Instance.GameOver();
        }
    }
}
