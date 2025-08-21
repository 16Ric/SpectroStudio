using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicNoteChords : MonoBehaviour
{
    public static MusicNoteChords Instance;
    public AudioSource unlockSound;

    // AudioSources for notes
    public AudioSource C_Note;
    public AudioSource D_Note;
    public AudioSource E_Note;
    public AudioSource F_Note;
    public AudioSource G_Note;
    public AudioSource A_Note;
    public AudioSource B_Note;

    // List to track the sequence of button presses
    private List<string> noteSequence = new List<string>();

    // Correct sequence to unlock the door
    private string[] correctSequence = new string[] { "A", "F", "G", "E", "D" };

    // Boolean to store whether the correct sequence has been played
    private bool isCorrectSequence = false;

    public void C_Note_Play()
    {
        C_Note.Play();
        AddNoteToSequence("C");
    }

    public void D_Note_Play()
    {
        D_Note.Play();
        AddNoteToSequence("D");
    }

    public void E_Note_Play()
    {
        E_Note.Play();
        AddNoteToSequence("E");
    }

    public void F_Note_Play()
    {
        F_Note.Play();
        AddNoteToSequence("F");
    }

    public void G_Note_Play()
    {
        G_Note.Play();
        AddNoteToSequence("G");
    }

    public void A_Note_Play()
    {
        A_Note.Play();
        AddNoteToSequence("A");
    }

    public void B_Note_Play()
    {
        B_Note.Play();
        AddNoteToSequence("B");
    }

    // Adds the note to the sequence and checks for the correct order
    private void AddNoteToSequence(string note)
    {
        noteSequence.Add(note);

        // Keep only the last 5 notes in the sequence
        if (noteSequence.Count > correctSequence.Length)
        {
            noteSequence.RemoveAt(0);  // Remove the oldest note to maintain a sequence of max 5 notes
        }

        // Check if the current sequence matches the correct sequence
        CheckSequence();
    }

    // Checks if the last 5 notes match the correct sequence
    private void CheckSequence()
    {
        if (noteSequence.Count == correctSequence.Length)
        {
            bool isCorrect = true;
            for (int i = 0; i < correctSequence.Length; i++)
            {
                if (noteSequence[i] != correctSequence[i])
                {
                    isCorrect = false;
                    break;
                }
            }

            if (isCorrect)
            {
                isCorrectSequence = true;
                Debug.Log("Correct sequence played!");
                if (unlockSound != null)
                {
                    unlockSound.Play();  
                }
            }
        }
    }

    // Reset the sequence if needed
    private void ResetSequence()
    {
        noteSequence.Clear();
        isCorrectSequence = false;
    }

    // Public method to check if the correct notes have been played
    public bool IsCorrectNotes()
    {
        return isCorrectSequence;
    }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
