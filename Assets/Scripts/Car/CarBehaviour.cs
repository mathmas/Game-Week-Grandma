using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script is the behaviour of the cars
 * It makes the cars move
 */
public class CarBehaviour : MonoBehaviour
{
    public float speed, maxSpeed, maxForce;
    public Rigidbody rb;
    public Vector3 direction;
    public Animator animator;
    public GameObject particleExplosion;

    public MeshRenderer carMaterial;

    [SerializeField] private List<Material> materials = new List<Material>();

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        maxSpeed = speed;

        animator.SetBool("isMoving", true);

        //choose rnd material
        carMaterial.material = materials[Random.Range(0, materials.Count)];
    }

    //Car movement
    private void FixedUpdate()
    {
        Vector3 currentVelocity = rb.velocity;
        Vector3 targetVelocity = direction;
        targetVelocity *= speed;

        Vector3 velocityChange = targetVelocity - currentVelocity;

        Vector3.ClampMagnitude(velocityChange, maxForce);

        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision col)
    {
        if(!col.gameObject.CompareTag("Player"))
        {
            animator.SetBool("isDead", true);
            particleExplosion.SetActive(true);
            Destroy(this.gameObject, 1f);
        }
    }
}
