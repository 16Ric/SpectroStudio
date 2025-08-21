using System.Collections;
using UnityEngine;

public class DoorFinalManager : MonoBehaviour
{
    // References to the closed and opened doors
    public GameObject finalDoorClosed;
    public GameObject finalDoorOpened;

    // Reference to the AudioSource component for playing door unlock sound
    public AudioSource audioSource;

    // Reference to the CameraShake script attached to the camera
    public Camera mainCamera;
    public float shakeDuration = 1f;   // Duration of the camera shake
    public float shakeMagnitude = 0.3f; // Intensity of the shake

    // Reference to the Countdown script
    public Countdown countdown; 

    // Reference to the earthquake dialogue UI
    public GameObject earthquakeDialogue;

    // Flag to check if the final door is unlocked
    private bool finalUnlocked = false;

    void Awake()
    {
        // Ensure the final opened door is initially inactive
        if (finalDoorOpened != null)
        {
            finalDoorOpened.SetActive(false);
        }

        // Ensure the AudioSource is set up correctly
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        // Reference the main camera for the shake effect
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }

        // Ensure the earthquake dialogue is hidden at the start
        if (earthquakeDialogue != null)
        {
            earthquakeDialogue.SetActive(false);
        }
    }

    void Update()
    {
        // Check if all necessary conditions to unlock the final door are met
        if (!finalUnlocked && CorrectSymbolManager.Instance != null && CorrectSymbolManager.Instance.AreAllSymbolsActivated())
        {
            UnlockFinal();
        }
    }

    // Method to unlock the final door
    private void UnlockFinal()
    {
        if (!finalUnlocked && finalDoorClosed != null && finalDoorOpened != null)
        {
            finalUnlocked = true;
            Debug.Log("Final door unlocked.");

            // Play the door unlock sound if the AudioSource is set
            if (audioSource != null && !audioSource.isPlaying)
            {
                audioSource.Play();  // Play the unlock audio
            }

            StartCoroutine(DelayedUnlock());  // Call the coroutine to manage door activation

            // Trigger the camera shake effect
            if (mainCamera != null && countdown != null)
            {
                CameraShake cameraShake = mainCamera.GetComponent<CameraShake>();
                if (cameraShake != null)
                {
                    Debug.Log("Shake unlocked.");
                    StartCoroutine(cameraShake.Shake(60f, 0.5f));  // Trigger camera shake

                    // Show the earthquake dialogue
                    earthquakeDialogue.SetActive(true);

                    // Reduce the countdown timer to 30 seconds after the shake
                    countdown.SetRemainingTime(30f);  // Assuming you have a method to set remaining time
                }
                else
                {
                    Debug.LogWarning("CameraShake component is missing from the main camera.");
                }
            }
        }
    }

    // Coroutine to disable the closed door and enable the opened door after a delay
    private IEnumerator DelayedUnlock()
    {
        yield return new WaitForSeconds(0.7f);  // Wait for 0.7 seconds
        finalDoorClosed.SetActive(false);  // Disable the closed final door
        finalDoorOpened.SetActive(true);   // Enable the opened final door
    }

    // Check if the final door is unlocked
    public bool IsFinalUnlocked()
    {
        return finalUnlocked;
    }
}
