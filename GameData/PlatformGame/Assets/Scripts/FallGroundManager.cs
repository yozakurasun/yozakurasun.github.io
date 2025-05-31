using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallGroundManager : MonoBehaviour
{
    private Rigidbody2D _rb;
    private bool _isFall;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isFall == true)
        {
            _rb.AddForce(new Vector3(0, -5f, 0), ForceMode2D.Force);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerLeg"))
        {
            _isFall = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("DeadLine"))
        {
            Destroy(gameObject);
        }
    }
}
