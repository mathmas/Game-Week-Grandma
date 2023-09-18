using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarTrigger : MonoBehaviour
{
    CarBehaviour carBehaviour;

    private void Start()
    {
        carBehaviour = GetComponentInParent<CarBehaviour>();
    }
    private void OnTriggerStay(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            carBehaviour.currentSpeed = 0f;
        }
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            carBehaviour.currentSpeed = carBehaviour.maxSpeed;
        }
    }
}
