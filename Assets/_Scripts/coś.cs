using system;
using UnityEngine;
using UnityEngine.UI;

public class coś : MonoBehaviour
{
    public Text textComponent;
    public string message = "Hello, World!";
    public float displayDuration = 2.0f;

    private void Start()
    {
        if (textComponent != null)
        {
            textComponent.text = message;
            Invoke("ClearText", displayDuration);
        }
        else
        {
            Debug.LogError("Text component is not assigned.");
        }
    }

    private void ClearText()
    {
        if (textComponent != null)
        {
            textComponent.text = "";
        }
    }
}ing System;