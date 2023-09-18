using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5;
    public Vector2 movementInput;
    public bool action1Input = false;

    public Material playerMaterial;

    private void Update()
    {
        transform.Translate(new Vector3(movementInput.x,0, movementInput.y) * speed * Time.deltaTime);

        if(action1Input)
        {
            playerMaterial.color = Color.red;
            speed = 0f; 
        }

    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
    public void OnAction1(InputAction.CallbackContext ctx) => action1Input = ctx.ReadValueAsButton();
}
