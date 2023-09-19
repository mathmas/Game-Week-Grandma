using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Variables
    public float speed, maxForce;
    private float maxSpeed;
    [SerializeField] private float slowDivision;
    public Rigidbody rb;

    #region Inputs
    public Vector2 movementInput;
    public bool stopActionInput = false;
    #endregion

    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        maxSpeed = speed;
    }

    private void Update()
    {

        if(stopActionInput)
        {
            speed = maxSpeed / slowDivision;
        }else
        {
            speed = maxSpeed;
        }
    }

    //Player movements
    private void FixedUpdate()
    {
        Vector3 currentVelocity = rb.velocity;
        Vector3 targetVelocity = new Vector3(movementInput.x, rb.velocity.y, movementInput.y);
        targetVelocity *= speed;

        Vector3 velocityChange = targetVelocity - currentVelocity;

        Vector3.ClampMagnitude(velocityChange, maxForce);

        rb.AddForce(velocityChange, ForceMode.VelocityChange);  
    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
    public void OnAction1(InputAction.CallbackContext ctx) => stopActionInput = ctx.ReadValueAsButton();
}
