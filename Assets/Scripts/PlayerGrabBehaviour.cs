using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Grab"))
        {
            Rigidbody rb = col.GetComponent<Rigidbody>();
            Collider collider = col.GetComponent<Collider>();

            rb.isKinematic = true;

        }
    }
}
