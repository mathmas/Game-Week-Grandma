using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * This script destroy the cars when it enter the Trigger
 */
public class CarDestroyer : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Car"))
        {
            Destroy(col.gameObject);
        }
    }
}
