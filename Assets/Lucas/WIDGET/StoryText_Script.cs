using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class StoryText_Script : MonoBehaviour
{
    public TextMeshProUGUI TextMesh1;
    public TextMeshProUGUI TextMesh2;
    public TextMeshProUGUI TextMesh3;
    public TextMeshProUGUI TextMesh4;
    public TextMeshProUGUI TextMesh5;

    public bool text2 = false;
    public bool text3 = false;
    public bool text4 = false;
    public bool text5 = false;

    public bool startGame = false;

    // Get the index of the next level (All levels must be added in the Build Setting)
    public int sceneBuildIndex;

    private void Start()
    {
        TextMesh1.gameObject.SetActive(false);
        TextMesh2.gameObject.SetActive(false);
        TextMesh3.gameObject.SetActive(false);
        TextMesh4.gameObject.SetActive(false);
        TextMesh5.gameObject.SetActive(false);
    }

    private void Update()
    {
        TextMesh1.gameObject.SetActive(true);
        StartCoroutine(TextMesh1Coroutine());

        if(text2 == true)
        {
            TextMesh2.gameObject.SetActive(true);
            StartCoroutine(TextMesh2Coroutine());

            if(text3 == true)
            {
                TextMesh3.gameObject.SetActive(true);
                StartCoroutine(TextMesh3Coroutine());

                if(text4 == true) 
                {
                    TextMesh4.gameObject.SetActive(true);
                    StartCoroutine(TextMesh4Coroutine());

                    if(text5 == true) 
                    {
                        TextMesh5.gameObject.SetActive(true);
                        StartCoroutine(TextMesh5Coroutine());

                        if(startGame == true)
                        {
                            // This will load the next index scene
                            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
                        }
                    }
                }
            }
        }
    }

    IEnumerator TextMesh1Coroutine()
    {
        yield return new WaitForSeconds(5);
        text2 = true;
    }

    IEnumerator TextMesh2Coroutine()
    {
        yield return new WaitForSeconds(3);
        text3 = true;
    }

    IEnumerator TextMesh3Coroutine()
    {
        yield return new WaitForSeconds(7);
        text4 = true;
    }

    IEnumerator TextMesh4Coroutine()
    {
        yield return new WaitForSeconds(5);
        text5 = true;
    }

    IEnumerator TextMesh5Coroutine()
    {
        yield return new WaitForSeconds(5);
        startGame = true;
    }
}
