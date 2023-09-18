using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard_Car_Script : MonoBehaviour
{
    public GameObject Car;

    public bool IsCarAlive;

    public int Speed;
    private Rigidbody _rb;

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

            // Doesnt work
            //Movement();

        }
        else
        {
            // Car dead so destroy
            Destroy(Car);
        }
    }

    private void Movement()
    {
        var vel = new Vector3(0, 0, 0) * Speed;

        vel.y = _rb.velocity.y;

        _rb.velocity = vel;
    }
}
