using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Variables
    public float currentSpeed;
    public float maxSpeed = 5;

    #region Inputs
    public Vector2 movementInput;
    public bool stopActionInput = false;
    #endregion

    #endregion

    private void Start()
    {
        currentSpeed = maxSpeed;
    }

    private void Update()
    {
        transform.Translate(new Vector3(movementInput.x,0, movementInput.y) * currentSpeed * Time.deltaTime);

        //A ameliorer, c'est trop brouillon
        if(stopActionInput)
        {
            currentSpeed = 0f;
        }else
        {
            currentSpeed = maxSpeed;
        }

    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
    public void OnAction1(InputAction.CallbackContext ctx) => stopActionInput = ctx.ReadValueAsButton();
}
