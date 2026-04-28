using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    float secondsPassed;
    public float maxSecondsPassed;
    public GameObject[] pipePrefabs;
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
        //Pick a random index from the array
        int randomIndex = Random.Range(0, pipePrefabs.Length);

        //Instantiate the random prefab
        GameObject newPipe = Instantiate(pipePrefabs[randomIndex]);

        //Position it
        float newRandomHeight = Random.Range(-randomHeight, randomHeight);
        newPipe.transform.position = transform.position + new Vector3(0, newRandomHeight, 0);

        //Cleanup
        Destroy(newPipe, 12);
    }
}