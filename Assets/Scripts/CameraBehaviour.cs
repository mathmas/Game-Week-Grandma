using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script makes the camera follow the grandma with some smoothness
 */
public class CameraBehaviour : MonoBehaviour
{
    public Transform target;

    [SerializeField] private float smoothSpeed;
    [SerializeField] private Vector3 offset;


    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
