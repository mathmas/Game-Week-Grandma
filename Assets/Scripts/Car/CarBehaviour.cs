using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CarBehaviour : MonoBehaviour
{
    public float maxSpeed;
    public float currentSpeed;

    private void Start()
    {
        currentSpeed = maxSpeed;
    }

    private void Update()
    {
        transform.Translate(Vector3.forward * currentSpeed * Time.deltaTime);
    }
}
