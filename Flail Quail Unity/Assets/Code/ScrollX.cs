using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollX : MonoBehaviour
{
    public float movementSpeed;
    Vector3 initialPosition;
    public float minXPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        transform.position += Vector3.left * movementSpeed * Time.deltaTime;

        if (transform.position.x < minXPosition)
        {
            transform.position = initialPosition;
        }
    }
}
