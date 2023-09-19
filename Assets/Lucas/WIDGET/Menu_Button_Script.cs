using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Button_Script : MonoBehaviour
{
    // Get the index of the next level (All levels must be added in the Build Setting)
    public int sceneBuildIndex;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Button_Play()
    {
    // This will load the next index scene
    SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);

    }

    public void Button_Quit()
    {
        Application.Quit();
        Debug.Log("Quit");

    }
}
