using System.Collections;
using UnityEngine;
using TMPro;  // Ensure you are using TextMeshPro

public class BookTrigger : MonoBehaviour
{
    public GameObject paper;
    public GameObject paperDialogue;
    private bool isPlayerInTrigger = false;
    private bool bookHasBeenRead = false;
    public string bookName;

    public static bool isReading = false;  // Global flag to track if the player is reading
    public BookManager associatedBookManager;

    void Start()
    {
        if (paper != null)
        {
            paper.SetActive(false);  // Make sure the paper is invisible at the start
        }

        if (paperDialogue != null)
        {
            paperDialogue.SetActive(false);  // Ensure paperDialogue is hidden at the start
        }
    }

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
            if (paper != null)
            {
                StartCoroutine(DelayedSetActive(false));
                isReading = false;  // Player is no longer reading
            }

            if (paperDialogue != null)
            {
                paperDialogue.SetActive(false);  // Hide the dialogue when the player leaves the trigger
            }
        }
    }

    void Update()
    {
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.F))
        {
            if (paper != null)
            {
                bool shouldShow = !paper.activeSelf;
                StartCoroutine(DelayedSetActive(shouldShow));  // Toggle the active state of the paper with a delay

                // Mark the book as read and notify the specific BookManager
                if (!bookHasBeenRead)
                {
                    bookHasBeenRead = true;
                    if (associatedBookManager != null)
                    {
                        associatedBookManager.ReadBook(bookName);  // Use the associated BookManager
                    }
                }

                // Show the dialogue with "(click to continue)" when the paper appears
                if (shouldShow && paperDialogue != null)
                {
                    paperDialogue.SetActive(true);  // Show the dialogue
                    TextMeshProUGUI textComponent = paperDialogue.GetComponent<TextMeshProUGUI>();
                    if (textComponent != null)
                    {
                        textComponent.text = "(click to continue)";  // Set the text message
                    }
                    isReading = true;  // Set isReading to true when the player is reading
                }
                else
                {
                    isReading = false;  // Set isReading to false when the paper is closed
                }
            }
        }
    }

    private IEnumerator DelayedSetActive(bool state)
    {
        yield return new WaitForSeconds(.5f);  // Wait for 0.5 seconds
        paper.SetActive(state);  // Set the active state of the paper
    }
}
