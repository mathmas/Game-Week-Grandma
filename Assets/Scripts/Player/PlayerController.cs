using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region Variables
    #region movements
    public float speed, maxForce;
    private float maxSpeed;
    [SerializeField] private float slowDivision;
    #endregion

    public Rigidbody rb;
    public GameObject trigger;
    private GameObject gameManager;

    public MeshRenderer meshRenderer;

    #region Inputs
    public Vector2 movementInput;
    public bool stopActionInput = false;
    public bool interactInput = false;
    #endregion

    #endregion

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        maxSpeed = speed;
        SetGameManager();
    }

    private void Update()
    {

        if (stopActionInput)
        {
            speed = maxSpeed / slowDivision;
        } else
        {
            speed = maxSpeed;
        }

        if (interactInput)
        {
            Debug.Log("interact Input");
            trigger.SetActive(true);
        } else
        {
            trigger.SetActive(false);
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
        //makes player look forward
        transform.LookAt(new Vector3(transform.position.x + targetVelocity.x, transform.position.y, transform.position.z + targetVelocity.z));
    }

    public void OnMove(InputAction.CallbackContext ctx) => movementInput = ctx.ReadValue<Vector2>();
    public void OnAction1(InputAction.CallbackContext ctx) => stopActionInput = ctx.ReadValueAsButton();
    public void OnAction2(InputAction.CallbackContext ctx) => interactInput = ctx.ReadValueAsButton();

    private void SetGameManager()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        if (gameManager != null)
        {
            GameManager gameManagerScript = gameManager.GetComponent<GameManager>();
            gameManagerScript.playersObj.Add(this.gameObject);
        }
    }
}
