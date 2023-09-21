using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using static UnityEngine.EventSystems.EventTrigger;

public class GoalScript : MonoBehaviour
{
    public GameObject Collider;

    public GameObject EventSystem;

    public AudioSource audioSource;
    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.name == "Grandma character")
        {
            Debug.Log("Granda is here");
            //Time.timeScale = 0f;

            StartCoroutine(VictoryCoroutine());
            audioSource.PlayOneShot(audioClip);

        }

    }

    IEnumerator VictoryCoroutine()
    {
        yield return new WaitForSeconds(5);
        EventSystem.GetComponent<VictoryLosing_UI_Script>().Victory();
    }

}
