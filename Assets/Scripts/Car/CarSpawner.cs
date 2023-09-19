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
        GameObject carSpawed = Instantiate(carPrefab, transform.position, carPrefab.transform.rotation);
        CarBehaviour carBehaviour = carSpawed.GetComponent<CarBehaviour>();

        if (carGoesLeft)
        {
            carBehaviour.transform.Rotate(new Vector3(0f, 180f, 0f));
            carBehaviour.direction = Vector3.right;
        }else
        {
            carBehaviour.direction = Vector3.left;
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
