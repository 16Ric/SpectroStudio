using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorStage2Manager : MonoBehaviour
{
    public static DoorStage2Manager Instance;  // Singleton instance

    // References to the closed and opened doors
    public GameObject stage2DoorClosed;
    public GameObject stage2DoorOpened;

    // Reference to the AudioSource component for playing door unlock sound
    public AudioSource audioSource;

    // Reference to the specific BookManager for this door
    public BookManager associatedBookManager;  

    // Flag to check if Stage 2 is unlocked
    private bool stage2Unlocked = false;

    void Awake()
    {
        // Ensure there is only one instance of DoorStage2Manager
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Keeps the instance alive across different scenes
        }
        else
        {
            Destroy(gameObject);  // Ensures that there is only one instance of this object
        }

        // Ensure the stage 2 opened door is initially inactive
        if (stage2DoorOpened != null)
        {
            stage2DoorOpened.SetActive(false);
        }

        // Ensure the AudioSource is set up correctly
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }
    }

    void Update()
    {
        // Check if all books associated with this door have been read
        if (!stage2Unlocked && associatedBookManager != null && associatedBookManager.haveAllBooksBeenRead())
        {
            UnlockStage2();
        }
    }

    // Method to unlock Stage 2 door
    private void UnlockStage2()
    {
        if (!stage2Unlocked && stage2DoorClosed != null && stage2DoorOpened != null)
        {
            stage2Unlocked = true;
            Debug.Log("Stage 2 unlocked.");

            // Play the door unlock sound if the AudioSource is set
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();  // Play the unlock audio
            }

            StartCoroutine(DelayedUnlock()); // Call the coroutine to manage door activation
        }
    }

    // Coroutine to disable the closed door and enable the opened door after a delay
    private IEnumerator DelayedUnlock()
    {
        yield return new WaitForSeconds(0.7f);  // Wait for 0.7 seconds
        stage2DoorClosed.SetActive(false);  // Disable the closed stage 2 door
        stage2DoorOpened.SetActive(true);   // Enable the opened stage 2 door
    }

    // Check if Stage 2 is unlocked
    public bool IsStage2Unlocked()
    {
        return stage2Unlocked;
    }
}
