using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private Vector2 _jumpForce;

    private bool _isGround;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
            Jump();
    }

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && _isGround == true)
        {
            rb.AddForce(_jumpForce, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            _isGround = true;
        }
        else if (collision.gameObject.CompareTag("Obstacles"))
        {
            GameManager.Instance.GameOver(true);
        }
    }
}
