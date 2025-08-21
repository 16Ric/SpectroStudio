using System.Collections;
using UnityEngine;
using TMPro;

public class PaperDialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;  // The UI TextMeshPro component
    public string[] lines;                 // Lines of dialogue
    public float textSpeed = 0.05f;        // Speed at which the text is displayed

    private int index = 0;                 // Current line index

    void Start()
    {
        textComponent.text = string.Empty; // Start with empty text
    }

    // Call this method to trigger the paper dialogue
    public void StartPaperDialogue()
    {
        index = 0;
        textComponent.text = string.Empty; // Clear text
        gameObject.SetActive(true);        // Make dialogue visible
        StartCoroutine(TypeLine());        // Start typing the first line
    }

    private IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;       // Add character to text component
            yield return new WaitForSeconds(textSpeed); // Wait between characters
        }
    }

    public void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty; // Clear text for next line
            StartCoroutine(TypeLine());        // Type next line
        }
        else
        {
            EndDialogue();                     // End dialogue when done
        }
    }

    void EndDialogue()
    {
        textComponent.text = string.Empty;     // Clear text
        gameObject.SetActive(false);           // Hide dialogue
    }

    void Update()
    {
        // If player clicks the mouse button, show the next line
        if (Input.GetMouseButtonDown(0))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();  // If full line is displayed, show the next one
            }
            else
            {
                StopAllCoroutines();           // Stop the typing effect
                textComponent.text = lines[index]; // Instantly show the full line
            }
        }
    }
}
