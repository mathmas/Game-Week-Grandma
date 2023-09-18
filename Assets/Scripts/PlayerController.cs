using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float currentSpeed;
    public float maxSpeed = 5;
    public Vector2 movementInput;
    public bool action1Input = false;

    public string state = "moving";

    private void Start()
    {
        currentSpeed = maxSpeed;
    }

    private void Update()
    {
        transform.Translate(new Vector3(movementInput.x,0, movementInput.y) * currentSpeed * Time.deltaTime);

        if(action1Input)
        {
            state = "stop";
            currentSpeed = 0f;
        }else
        {
            state = "moving";
            currentSpeed = maxSpeed;

        }

    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
    public void OnAction1(InputAction.CallbackContext ctx) => action1Input = ctx.ReadValueAsButton();
}
