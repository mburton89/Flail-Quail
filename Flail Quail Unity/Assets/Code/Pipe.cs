using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float movementSpeed;

    public bool movesVertical = false;
    public float verticalRange;
    public float verticalSpeed;
    private float startY;

    void Start()
    {
        startY = transform.position.y;
    }

    void Update()
    {
        //standard left movement
        transform.position += Vector3.left * movementSpeed * Time.deltaTime;

        if (movesVertical)
        {
            //calculates smooth up and down affect
            float newY = startY + Mathf.Sin(Time.time * verticalSpeed) * verticalRange;

            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }
}