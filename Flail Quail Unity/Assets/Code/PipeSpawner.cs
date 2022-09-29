using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    float secondsPassed;
    public float maxSecondsPassed;
    public GameObject pipePrefab;
    public float randomHeight;

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
        float newRandomHeight = Random.Range(-randomHeight, randomHeight);
        newPipe.transform.position = transform.position + new Vector3(0, newRandomHeight, 0);
        Destroy(newPipe, 12);
    }
}
