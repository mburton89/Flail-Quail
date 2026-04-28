using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    Vector3 initialPosition;
    public float minXPosition;

    public float scrollSpeed;

    private void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        //TODO: Give the ability to adjust speed
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        if (transform.position.x < minXPosition)
        {
            transform.position = initialPosition;
        }
    }
}