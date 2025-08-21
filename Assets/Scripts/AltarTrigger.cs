using System.Collections;
using UnityEngine;
using TMPro;

public class AltarTrigger : MonoBehaviour
{
    public GameObject paperDialogue;
    public GameObject puzzleTemplate;
    private bool isPlayerInTrigger = false;

    public static bool isReading = false;  // Global flag to track if the player is reading


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            if (paperDialogue != null)
            {
                paperDialogue.SetActive(true);  // Show the dialogue
                TextMeshProUGUI textComponent = paperDialogue.GetComponent<TextMeshProUGUI>();
                if (textComponent != null)
                {
                    textComponent.text = "Press 'F' to interact";  // Show the instruction
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;

            if (paperDialogue != null)
            {
                paperDialogue.SetActive(false);  // Hide the dialogue when the player leaves the trigger
            }
        }
    }
    private void Update()
    {
        // Check if the player is inside the trigger and presses 'F'
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.F))
        {
            // Set the puzzleTemplate active when F is pressed
            if (puzzleTemplate != null)
            {
                puzzleTemplate.SetActive(true);  // Activate the puzzle template
            }

            if (paperDialogue != null)
            {
                paperDialogue.SetActive(false);  // Hide the dialogue after interaction
            }
        }
    }


}
