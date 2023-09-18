using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard_Car_Script : MonoBehaviour
{
    public GameObject Car;
    public Transform CarTransform;
    public Rigidbody CarRB;

    public bool IsCarAlive;

    public int Speed;

    private bool isCoroutineRunning = false;


    // Start is called before the first frame update
    void Start()
    {
        IsCarAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsCarAlive == true)
        {
            // Car moves

            Movement();
            StartCoroutine(RespawnCoroutine());
            isCoroutineRunning = true;

            if (isCoroutineRunning == false)
            {
                Debug.Log("Respawn Car");
                // NEED RESPAWN CODE
            }

        }
        else
        {
            // Car dead so destroy
            Destroy(Car);
        }
    }

    IEnumerator RespawnCoroutine()
    {
        print("Starting Coroutine Execution");

        yield return new WaitForSeconds(5);

        print("Coroutine as ended, Respawning Car");
        isCoroutineRunning = false;
    }

    private void Movement()
    {
        CarRB.velocity = transform.TransformDirection(new Vector3(Speed, 0, 0));
    }
}
