using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VictoryLosing_UI_Script : MonoBehaviour
{
    public Text VictoryText;
    public Text LoseText;
    public GameObject BackgroundImage;

    // Start is called before the first frame update
    void Start()
    {
        VictoryText.gameObject.SetActive(false);
        LoseText.gameObject.SetActive(false);
        BackgroundImage.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // if Victory = true alors SetActive(true);
        // if Lose = true alors SetActive(true);
    }
}
