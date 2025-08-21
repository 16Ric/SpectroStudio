using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeBook : MonoBehaviour
{
    public Animator playerAnimator; // Reference to the player's animator
    private bool isPlayerInTrigger = false;

    void Start()
    {
        if (playerAnimator == null)
        {
            Debug.LogError("Player Animator is not assigned!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is in the trigger zone and presses F
        if (isPlayerInTrigger && Input.GetKeyDown(KeyCode.F))
        {
            // Play the player's "TakeBook" animation
            playerAnimator.SetBool("isTakeBook", true);
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("Player is not in the trigger zone to take the book.");
        }
    }

    // When the player enters the trigger zone
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = true;
            Debug.Log("Player entered the trigger zone.");
        }
    }

    // When the player exits the trigger zone
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInTrigger = false;
            Debug.Log("Player left the trigger zone.");

            // Reset the "TakeBook" animation to false when the player exits
            playerAnimator.SetBool("isTakeBook", false);
        }
    }
}
