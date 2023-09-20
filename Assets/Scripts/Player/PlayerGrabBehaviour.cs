using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * This script is enable when the player press Action2
 * It let the player grab item by pressing Action2 button
 * The player has to hold the button to keep the object in his hands
 */

public class PlayerGrabBehaviour : MonoBehaviour
{
    #region Throw Vars
    [SerializeField] private float throwMultiplicator;
    [SerializeField] private float verticalThrowForce;
    #endregion

    #region GameObejct Vars
    public GameObject grabPoint;
    public GameObject grabedObject;
    public GameObject player;
    #endregion
    //  The player can't hold the button if he doesn't have a object in his hands.
    private void OnEnable()
    {
        if (grabPoint.transform.childCount > 0)
        {
            this.gameObject.SetActive(false);
        }
    }

    //  The object is almost desactivate when he is grabed
    //  It doesn't have physics and collison
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

    //Throw the grabed item
    private void OnDisable()
    {
        Rigidbody rb = grabedObject.GetComponent<Rigidbody>();
        Collider collider = grabedObject.GetComponent<Collider>();

        rb.isKinematic = false;
        collider.isTrigger = false;

        grabedObject.transform.SetParent(null);
        Rigidbody playerRB = player.GetComponent<Rigidbody>();
        rb.AddForce(playerRB.velocity * throwMultiplicator + Vector3.up * verticalThrowForce, ForceMode.VelocityChange);
    }
}
