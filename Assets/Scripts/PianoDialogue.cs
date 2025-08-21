using System.Collections;
using UnityEngine;
using TMPro;

public class PianoDialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent; 
    public string[] lines; 
    public float textSpeed = 0.07f; 
    private int index; 
    private bool isFirstLine = true; 

    void Update()
    {
        // Check for the E key press to start the dialogue
        if (isFirstLine && Input.GetKeyDown(KeyCode.E))
        {
            StartDialogue(); 
            isFirstLine = false; 
        }

        // Check for mouse click to proceed with the dialogue
        if (!isFirstLine && Input.GetMouseButtonDown(0))
        {
            NextLine(); // Proceed to the next line on mouse click
        }
    }

    void StartDialogue()
    {
        index = 0; 
        textComponent.text = string.Empty; // Clear any existing text
        StartCoroutine(TypeLine()); 
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c; 
            yield return new WaitForSeconds(textSpeed); 
        }
        yield return new WaitForSeconds(1f); 
    }

    void NextLine()
    {
        if (index < lines.Length - 1) 
        {
            index++; 
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine()); 
        }
        else
        {
            textComponent.text = string.Empty; 
            gameObject.SetActive(false); 
        }
    }
}
