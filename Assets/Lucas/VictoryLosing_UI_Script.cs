using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryLosing_UI_Script : MonoBehaviour
{
    public GameObject VictoryAssets;
    public GameObject LoseAssets;
    public GameObject BackgroundImage;

    public int sceneBuildIndex;

    // Start is called before the first frame update
    void Start()
    {
        VictoryAssets.gameObject.SetActive(false);
        LoseAssets.gameObject.SetActive(false);
        BackgroundImage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Victory()
    {
        VictoryAssets.gameObject.SetActive(true);
        BackgroundImage.gameObject.SetActive(true);
    }

    public void Losing()
    {
        LoseAssets.gameObject.SetActive(true);
        BackgroundImage.gameObject.SetActive(true);
    }

    public void BackButton()
    {
        // This will load the next index scene
        SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
    }
}
