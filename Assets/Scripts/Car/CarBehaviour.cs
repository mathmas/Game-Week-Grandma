using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CarBehaviour : MonoBehaviour
{
    public float speed, maxSpeed, maxForce;
    public Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        maxSpeed = speed;
    }

    //Car movement
    private void FixedUpdate()
    {
        Vector3 currentVelocity = rb.velocity;
        Vector3 targetVelocity = Vector3.left;
        targetVelocity *= speed;

        Vector3 velocityChange = targetVelocity - currentVelocity;

        Vector3.ClampMagnitude(velocityChange, maxForce);

        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }
}