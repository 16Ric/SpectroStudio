using TMPro;
using UnityEngine;

public class DoorFinalTrigger : MonoBehaviour
{
    private KeyCode interactKey = KeyCode.E;  // Press "E" to interact
    public float sceneTransitionDelay = 0.5f;
    private bool playerInRange = false;
    public GameObject Dialogue;
    public SceneTransition sceneTransition;  // This will handle the scene transition to credits
    private DoorFinalManager doorFinalManager;  // Reference to DoorFinalManager

    void Start()
    {
        if (Dialogue != null)
        {
            Dialogue.SetActive(false); 
        }

        // Find and assign the DoorFinalManager in the scene (you can adjust how to get this reference)
        doorFinalManager = FindObjectOfType<DoorFinalManager>();
        
        if (doorFinalManager == null)
        {
            Debug.LogError("DoorFinalManager not found in the scene!");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player is near the final door.");
            TextMeshProUGUI textComponent = Dialogue.GetComponent<TextMeshProUGUI>();
            if (textComponent != null)
            {
                textComponent.text = "Press 'E' to Interact";  
                Dialogue.SetActive(true);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            Dialogue.SetActive(false);
            Debug.Log("Player left the final door area.");
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(interactKey))
        {
            if (doorFinalManager != null && doorFinalManager.IsFinalUnlocked())
            {
                Debug.Log("Entering the credits scene...");

                // Trigger the scene transition to the credits
                if (sceneTransition != null)
                {
                    doorFinalManager.gameObject.SetActive(false);
                    sceneTransition.GotoCreditScene(sceneTransitionDelay);  // Load the credits scene with a delay
                }
            }
            else
            {
                Debug.Log("Final stage is still locked.");
            }
        }
    }
}
