using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grandma_Script : MonoBehaviour
{
    public GameObject Grandma;
    public Transform GrandmaTransform;
    public Rigidbody GrandmaRB;

    public bool IsGrandmaAlive;

    public int Speed;


    // Start is called before the first frame update
    void Start()
    {
        IsGrandmaAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsGrandmaAlive == true)
        {
            // Grandma moves

            Movement();

        }
        else
        {
            // Grandma dead so destroy
            Destroy(Grandma);
        }
    }

    private void Movement()
    {
        GrandmaRB.velocity = transform.TransformDirection(new Vector3(0, Speed, 0));
    }
}
