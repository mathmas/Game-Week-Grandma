using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrabBehaviour : MonoBehaviour
{
    public GameObject grabPoint;
    public GameObject grabedObject;

    private void OnEnable()
    {
        if (grabPoint.transform.childCount > 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    private void OnDisable()
    {
        Rigidbody rb = grabedObject.GetComponent<Rigidbody>();
        Collider collider = grabedObject.GetComponent<Collider>();

        rb.isKinematic = false;
        collider.isTrigger = false;

        grabedObject.transform.SetParent(null);
    }

    private void OnTriggerEnter(Collider col)
    {
        if(grabPoint.transform.childCount <= 0)
        {
            if (col.CompareTag("Grab"))
            {
                if ((grabPoint.transform.childCount <= 0))
                {
                    Rigidbody rb = col.GetComponent<Rigidbody>();
                    Collider collider = col.GetComponent<Collider>();

                    rb.isKinematic = true;
                    collider.isTrigger = true;

                    col.transform.position = grabPoint.transform.position;
                    col.transform.SetParent(grabPoint.transform, true);
                    grabedObject = col.gameObject;
                }
            }
        }
    }
}
