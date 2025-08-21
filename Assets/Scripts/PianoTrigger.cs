using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PianoTrigger : MonoBehaviour
{
    public GameObject pianoKeys;
    public GameObject pianoDialogue;
    private bool isPlayerNearPiano = false; // To track if the player is near the piano

    void Start()
    {
        // Initially set the piano keys and dialogue inactive
        pianoKeys.SetActive(false);
        if (pianoDialogue != null)
        {
            pianoDialogue.SetActive(false);
        }
        Debug.Log("Piano keys and dialogue are initially inactive.");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearPiano = true;
            Debug.Log("Player near piano: Press 'E' to activate/deactivate piano keys.");

            // Show the dialogue prompting the player to press 'E'
            if (pianoDialogue != null)
            {
                pianoDialogue.SetActive(true);  // Show the dialogue when near the piano
                TextMeshProUGUI textComponent = pianoDialogue.GetComponent<TextMeshProUGUI>();
                if (textComponent != null)
                {
                    textComponent.text = "Press 'E' to Interact";
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerNearPiano = false;
            pianoKeys.SetActive(false); // Ensure piano keys deactivate when leaving

            // Hide the dialogue when the player leaves the piano area
            if (pianoDialogue != null)
            {
                pianoDialogue.SetActive(false);
            }
            Debug.Log("Player left piano area: Piano keys are now inactive, and dialogue is hidden.");
        }
    }

    void Update()
    {
        // Check if player is near the piano and presses the 'E' key
        if (isPlayerNearPiano && Input.GetKeyDown(KeyCode.E))
        {
            // Toggle the active state of the piano keys
            pianoKeys.SetActive(!pianoKeys.activeSelf);
            Debug.Log("Player pressed 'E': Piano keys are now " + (pianoKeys.activeSelf ? "active." : "inactive."));

            // Show the piano dialogue when interacting
            if (pianoDialogue != null)
            {
                pianoDialogue.SetActive(true);  // Show the dialogue when interacting with the piano
                TextMeshProUGUI textComponent = pianoDialogue.GetComponent<TextMeshProUGUI>();
            }
        }
    }
}
