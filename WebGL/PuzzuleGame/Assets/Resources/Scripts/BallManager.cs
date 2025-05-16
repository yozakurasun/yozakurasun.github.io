using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

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
    private string ballname;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        ballname = Enum.GetName(typeof(Balltype), balltype);
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space)) 
        {
            UseGravity();
        }
    }

    public void UseGravity()
    {
        rb.useGravity = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(ballname))
        { 
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
