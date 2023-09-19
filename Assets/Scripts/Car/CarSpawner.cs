using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate;

    private float timeLeft;
    public int objectBlockingSpawn;

    public GameObject carPrefab;

    private void Start()
    {
        timeLeft = spawnRate;
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0 && objectBlockingSpawn < 1)
        {
            Instantiate(carPrefab, transform.position, carPrefab.transform.rotation);
            timeLeft = spawnRate;
        }
    }

    private void OnTriggerEnter()
    {
        objectBlockingSpawn++;
    }
    private void OnTriggerExit()
    {
        objectBlockingSpawn--;
    }
}
