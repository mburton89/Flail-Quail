using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    float secondsPassed;
    public float maxSecondsPassed;
    public GameObject pipePrefab;

    void Start()
    {
        SpawnPipe();
    }

    void Update()
    {
        if (secondsPassed > maxSecondsPassed)
        {
            SpawnPipe();
            secondsPassed = 0;
        }

        secondsPassed += Time.deltaTime;
    }

    void SpawnPipe()
    {
        GameObject newPipe = Instantiate(pipePrefab);
        newPipe.transform.position = transform.position;
        //TODO: Set random height to Pipe
        //TODO: What can we do to improve performance
    }
}
