using TMPro;
using UnityEngine;

public class DoorStage3Trigger : MonoBehaviour
{
    private KeyCode interactKey = KeyCode.E;  // Press "E" to interact
    public float sceneTransitionDelay = 0.5f;
    private bool playerInRange = false;
    public GameObject Dialogue;
    public SceneTransition sceneTransition;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player is near the door to Stage 3.");
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
            Debug.Log("Player left the Stage 3 door area.");
            Dialogue.SetActive(false);
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(interactKey))
        {
            if (DoorStage3Manager.Instance != null && DoorStage3Manager.Instance.IsStage3Unlocked())
            {
                Debug.Log("Entering Stage 3...");

                // Trigger the scene transition
                if (sceneTransition != null)
                {
                    sceneTransition.GotoGameScene3(sceneTransitionDelay); 
                }
            }
            else
            {
                Debug.Log("Stage 3 is still locked.");
            }
        }
    }
}
