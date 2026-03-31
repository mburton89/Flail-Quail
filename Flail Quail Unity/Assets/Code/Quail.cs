using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quail : MonoBehaviour
{
    public float jumpVelocity;

    public Rigidbody2D rigidBody2D;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Flap();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Crash();
    }

    void Flap()
    {
        rigidBody2D.linearVelocity = Vector2.up * jumpVelocity;
    }

    void Crash()
    {
        //TODO: Play "Hurt" Sound
        //TODO: Show Game Over Menu
    }
}
