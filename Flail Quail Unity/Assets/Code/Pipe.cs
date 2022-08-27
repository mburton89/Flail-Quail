using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    public float movementSpeed;

    void Update()
    {
        transform.position += Vector3.left * movementSpeed * Time.deltaTime;
    }
}
