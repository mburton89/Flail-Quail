using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quail : MonoBehaviour
{
    public float jumpVelocity;
    public AudioSource jumpSound;
    public AudioSource hurtSound;
    Rigidbody2D rigidbody2D;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    void Jump()
    {
        rigidbody2D.velocity = Vector2.up * jumpVelocity;
    }

    void Lose()
    {

    }
}
