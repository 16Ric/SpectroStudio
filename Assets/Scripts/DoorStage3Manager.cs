using System.Collections;
using UnityEngine;

public class DoorStage3Manager : MonoBehaviour
{
    public static DoorStage3Manager Instance;

    // References to the closed and opened doors
    public GameObject stage3DoorClosed;
    public GameObject stage3DoorOpened;
    public AudioSource audioSource;

    // Reference to the specific BookManager for this door
    public BookManager associatedBookManager;

    // Singleton reference to the MusicNoteChords for note checking
    private MusicNoteChords musicNoteChords;

    private bool stage3Unlocked = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Keeps the instance alive across different scenes
        }
        else
        {
            Destroy(gameObject);  // Ensures that there is only one instance of this object
        }

        // Ensure the stage 3 opened door is initially inactive
        if (stage3DoorOpened != null)
        {
            stage3DoorOpened.SetActive(false);
        }

        // Ensure the AudioSource is set up correctly
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Start()
    {
        // Assign the MusicNoteChords singleton instance in Start
        musicNoteChords = MusicNoteChords.Instance;

        // Check if MusicNoteChords is assigned correctly
        if (musicNoteChords == null)
        {
            Debug.LogError("MusicNoteChords instance is null in DoorStage3Manager!");
        }
        else
        {
            Debug.Log("MusicNoteChords instance assigned successfully in DoorStage3Manager.");
        }
    }

    void Update()
    {
        // Check if the correct note sequence has been played and if all books have been read
        // if (!stage3Unlocked && associatedBookManager != null && associatedBookManager.haveAllBooksBeenRead() &&
        //     musicNoteChords != null && musicNoteChords.IsCorrectNotes())
        // {
        //     Debug.Log("Conditions met for unlocking Stage 3.");
        //     UnlockStage3();
        // }
        if (!stage3Unlocked && 
            musicNoteChords != null && musicNoteChords.IsCorrectNotes())
        {
            Debug.Log("Conditions met for unlocking Stage 3.");
            UnlockStage3();
        }
    }

    // Method to unlock Stage 3 door
    private void UnlockStage3()
    {
        if (!stage3Unlocked && stage3DoorClosed != null && stage3DoorOpened != null)
        {
            stage3Unlocked = true;
            Debug.Log("Stage 3 unlocked.");
            StartCoroutine(DelayedUnlock()); // Call the coroutine to manage door activation
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();  // Play the unlock audio
            }
        }
    }

    // Coroutine to disable the closed door and enable the opened door after a delay
    private IEnumerator DelayedUnlock()
    {
        Debug.Log("Unlocking the door...");
        yield return new WaitForSeconds(0.7f);  // Wait for 0.7 seconds
        stage3DoorClosed.SetActive(false);  // Disable the closed stage 3 door
        stage3DoorOpened.SetActive(true);   // Enable the opened stage 3 door
    }

    // Check if Stage 3 is unlocked
    public bool IsStage3Unlocked()
    {
        return stage3Unlocked;
    }
}
