using TMPro;
using UnityEngine;

public class DoorStage2Trigger : MonoBehaviour
{
    private KeyCode interactKey = KeyCode.E;  // Press "E" to interact
    public float sceneTransitionDelay = 0.5f;
    private bool playerInRange = false;
    public GameObject Dialogue;
    public SceneTransition sceneTransition;
    void Start()
    {
        if (Dialogue != null)
        {
            Dialogue.SetActive(false); 
        }
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("Player is near the door.");
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
            Debug.Log("Player left the door area.");
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(interactKey))
        {
            if (DoorStage2Manager.Instance != null && DoorStage2Manager.Instance.IsStage2Unlocked())
            {
                Debug.Log("Entering Stage 2...");
                
                // Trigger the scene transition
                if (sceneTransition != null)
                {
                    DoorStage2Manager.Instance.gameObject.SetActive(false);
                    sceneTransition.GotoGameScene2(sceneTransitionDelay);  // Load the next scene with a delay
                }
            }
            else
            {
                Debug.Log("Stage 2 is still locked.");
            }
        }
    }
}
