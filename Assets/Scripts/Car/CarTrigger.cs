using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTrigger : MonoBehaviour
{
    CarBehaviour carBehaviour;
    PlayerController playerController;

    public float maxWaitTime;
    public float restWaitTime;

    private void Start()
    {
        carBehaviour = GetComponentInParent<CarBehaviour>();
        restWaitTime = maxWaitTime;
    }

    //Stop moving if a player is stoping
    private void OnTriggerStay(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            playerController = col.GetComponent<PlayerController>();

            if(playerController.stopActionInput && restWaitTime > 0) 
            {
                carBehaviour.speed = 0f;
                restWaitTime -= Time.deltaTime;
            }
            else
            {
                carBehaviour.speed = carBehaviour.maxSpeed;
            }
        }
    }

    //The car doesnt run into each other
    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Car"))
        {
            carBehaviour.speed = 0f;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Car"))
        {
            carBehaviour.speed = carBehaviour.maxSpeed;
        }
    }
}
