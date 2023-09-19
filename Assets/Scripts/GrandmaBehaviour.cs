using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GrandmaBehaviour : MonoBehaviour
{

    [SerializeField] private float speed;

    public Rigidbody rb;
    public Transform checkpoint;

    private List<GameObject> checkpointsList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        for(int i = 0; i < checkpoint.childCount ; i++) 
        {
            checkpointsList.Add(checkpoint.GetChild(i).gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetVelocity = checkpointsList[0].transform.position - transform.position;

        if(Vector3.Distance(transform.position, checkpointsList[0].transform.position) < 1) 
        {
            Destroy(checkpointsList[0]);
            checkpointsList.RemoveAt(0);
        }
        targetVelocity.Normalize();
        
        targetVelocity *= speed; 
        rb.velocity = targetVelocity;

    }
}