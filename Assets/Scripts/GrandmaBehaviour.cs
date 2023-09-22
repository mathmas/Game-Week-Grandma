using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

/*
 * This script is the behaviour of the grandma
 * It makes the grandma move
 * The grandma move by going to chekcpoints
 */

public class GrandmaBehaviour : MonoBehaviour
{

    [SerializeField] private float speed;

    public Rigidbody rb;
    public Transform checkpoint;
    private GameObject gameManager;
    public Animator animator;
    public AudioSource gameOverSound;

    public GameObject EventSystem;

    private List<GameObject> checkpointsList = new List<GameObject>();

    // Start is called before the first frame update

    private void Awake()
    {
        SetGameManager();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        for(int i = 0; i < checkpoint.childCount ; i++) 
        {
            checkpointsList.Add(checkpoint.GetChild(i).gameObject);

            //Set the Y axis
            Vector3 chekcpointPos = checkpointsList[i].transform.position;
            chekcpointPos.y = transform.position.y + 0.5f;
            checkpointsList[i].transform.position = chekcpointPos;

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (checkpointsList[0] == null)
        {
            rb.isKinematic = true;
        }

        if(!rb.isKinematic)
        {
            animator.SetBool("isMoving", true);
            Vector3 targetVelocity = checkpointsList[0].transform.position - transform.position;

            if (Vector3.Distance(transform.position, checkpointsList[0].transform.position) < 2)
            {
                Destroy(checkpointsList[0]);
                checkpointsList.RemoveAt(0);
            }
            targetVelocity.Normalize();

            targetVelocity *= speed;
            rb.velocity = targetVelocity;
            transform.LookAt(checkpointsList[0].transform.position);
        }else
        {
            animator.SetBool("isMoving", false);
        }
    }
    private void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.CompareTag("Grab") || col.gameObject.CompareTag("Car"))
        {
            animator.SetBool("isDead", true);
            speed = 0;


            //Game Over script
            StartCoroutine(LosingCoroutine());
            gameOverSound.Play();
        }
    }

    private void SetGameManager()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        if (gameManager != null)
        {
            GameManager gameManagerScript = gameManager.GetComponent<GameManager>();
            gameManagerScript.grandma = this.gameObject;
        }
    }

    IEnumerator LosingCoroutine()
    {
        yield return new WaitForSeconds(2);
        EventSystem.GetComponent<VictoryLosing_UI_Script>().Losing();
    }

}
