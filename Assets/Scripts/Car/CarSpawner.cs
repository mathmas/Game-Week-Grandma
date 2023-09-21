using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script is a car spawner
 * It instantiates the cars with a spawnRate
 */
public class CarSpawner : MonoBehaviour
{
    public GameObject carPrefab;
    [SerializeField] private float spawnRate;
    [SerializeField] private Vector3 carDirection;

    private float timeLeft;

    private void Start()
    {
        carDirection.Normalize();
    }
    //Timer + initiates cars
    private void Update()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0)
        {
            SpawnCar();
            timeLeft = spawnRate;
        }
    }

    void SpawnCar()
    {
        GameObject carSpawed = Instantiate(carPrefab, transform.position, transform.rotation);
        CarBehaviour carBehaviour = carSpawed.GetComponent<CarBehaviour>();
        carBehaviour.direction = carDirection;

    }

}
