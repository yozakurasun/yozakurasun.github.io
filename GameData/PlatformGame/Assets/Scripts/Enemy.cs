using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameController.Instance.GameOver();
        }

        if (collision.gameObject.CompareTag("PlayerLeg"))
        {
            PlayerController.Instance.jump(true);
            Destroy(gameObject);
        }
    }
}
