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

    private void OnTriggerStay(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            playerController = col.GetComponent<PlayerController>();

            if(playerController.state == "stop" && restWaitTime > 0) 
            {
                carBehaviour.currentSpeed = 0f;
                restWaitTime -= Time.deltaTime;
            }
            else
            {
                carBehaviour.currentSpeed = carBehaviour.maxSpeed;
            }
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Car"))
        {
            carBehaviour.currentSpeed = 0f;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Car"))
        {
            carBehaviour.currentSpeed = carBehaviour.maxSpeed;
        }
    }
}
