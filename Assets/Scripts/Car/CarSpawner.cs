using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate;
    [SerializeField] private bool carGoesLeft;

    private float timeLeft;
    private int objectBlockingSpawn;

    public GameObject carPrefab;
    [SerializeField] private Vector3 carDirection;
    [SerializeField] private Quaternion carRotation;

    private void Start()
    {
        timeLeft = spawnRate;
    }

    private void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0 && objectBlockingSpawn < 1)
        {
            SpawnCar();
            timeLeft = spawnRate;
        }
    }

    void SpawnCar()
    {
        GameObject carSpawed = Instantiate(carPrefab, transform.position, carRotation);
        CarBehaviour carBehaviour = carSpawed.GetComponent<CarBehaviour>();
        carBehaviour.direction = carDirection;

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
