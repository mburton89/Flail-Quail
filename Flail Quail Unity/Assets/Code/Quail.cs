using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quail : MonoBehaviour
{
    public float jumpVelocity;
    public AudioSource jumpSound;
    public AudioSource hurtSound;
    Rigidbody2D rigidBody2D;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Jump();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Lose();
    }

    void Jump()
    {
        rigidBody2D.linearVelocity = Vector2.up * jumpVelocity;
        jumpSound.pitch = Random.Range(0.9f, 1.1f);
        jumpSound.Play();
    }

    void Lose()
    {
        hurtSound.Play();
        //TODO: Initiate Game Over Sequence
    }
}
