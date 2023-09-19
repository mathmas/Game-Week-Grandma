using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Title_Script : MonoBehaviour
{
    public Text legacyText;
    public float hoverDistance = 10f;
    public float hoverSpeed = 1f;

    private Vector3 startPos;
    private bool isGoingUp = true;

    private void Start()
    {
        if (legacyText == null)
        {
            Debug.LogError("Please assign the Legacy UI Text component.");
            enabled = false;
            return;
        }

        // Store the initial position of the text
        startPos = legacyText.rectTransform.localPosition;
    }

    private void Update()
    {
        // Calculate the vertical offset based on hoverDistance and time
        float yOffset = Mathf.Sin(Time.time * hoverSpeed) * hoverDistance;

        // Update the position of the text
        Vector3 newPosition = startPos + Vector3.up * yOffset;
        legacyText.rectTransform.localPosition = newPosition;
    }
}
