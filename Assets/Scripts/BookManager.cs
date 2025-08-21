using System.Collections;
using UnityEngine;

public class BookManager : MonoBehaviour
{
    public int totalBooks = 0;  // You can edit this in the Unity Inspector for each instance
    private int booksRead = 0;
    private bool booksHaveBeenRead = false;

    public GameObject hintDialogue;  // Reference to the HintDialogue UI
    public UIManager associatedUIManager;

    void Awake()
    {
        if (totalBooks <= 0)
        {
            Debug.LogError("totalBooks is not set or is less than or equal to 0. Please assign the correct number of books in the Inspector.");
        }

        if (hintDialogue != null)
        {
            hintDialogue.SetActive(false);
            Debug.Log("HintDialogue set to inactive on Awake.");
        }
    }

    // Method to be called whenever a book is read
    public void ReadBook(string bookName)
    {
        booksRead++;
        if (associatedUIManager != null)
        {
            associatedUIManager.UpdateBooksRead(booksRead, totalBooks);  // Update the UI for this specific instance
        }

        if (booksRead >= totalBooks)
        {
            Debug.Log("All books read! Waiting for player to finish reading the last book...");
            booksHaveBeenRead = true;  // Set to true when all books are read
        }
    }

    void Update()
    {
        // Check if all books are read and the player is not currently reading
        if (booksHaveBeenRead && !BookTrigger.isReading)
        {
            StartCoroutine(ShowHintDialogueAfterDelay(1f));
            booksHaveBeenRead = false;
            if (!hintDialogue.activeSelf)
            {
                StartCoroutine(ShowHintDialogueAfterDelay(1f));
            }
        }
    }

    // Coroutine to show the hint dialogue after a 2-second delay
    private IEnumerator ShowHintDialogueAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);  // Wait for the specified delay (1 second)

        if (hintDialogue != null && !hintDialogue.activeSelf)
        {
            hintDialogue.SetActive(true);  // Show the hint dialogue
            Debug.Log("Hint dialogue is now visible after 1 second.");
        }
    }

    // Method to check whether all books have been read
    public bool haveAllBooksBeenRead()
    {
        return booksHaveBeenRead;
    }

    // Optional: Reset the book manager for reuse
    public void ResetBooks()
    {
        booksRead = 0;
        booksHaveBeenRead = false;  // Reset this flag when resetting books
        if (associatedUIManager != null)
        {
            associatedUIManager.UpdateBooksRead(booksRead, totalBooks);  // Reset the UI for this specific instance
        }
    }
}
