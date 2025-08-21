using System.Collections;
using UnityEngine;
using TMPro;

public class GameController : MonoBehaviour
{
    [SerializeField] Countdown countdown;  // Reference to the Countdown script
    [SerializeField] Animator librarianAnimator;  // Reference to the Librarian's Animator
    [SerializeField] Transform librarianTransform;  // Reference to the Librarian's Transform
    [SerializeField] Transform johnTransform;  // Reference to John's Transform
    [SerializeField] GameObject johnBookPrefab;  // Reference to the JohnBook prefab
    [SerializeField] GameObject loseDialogue;  // Reference to the LoseDialogue UI element
    [SerializeField] float librarianSpeed = 3.5f;  // Speed at which the Librarian moves
    [SerializeField] float stopDistance = 2f;  // Distance from John at which the Librarian stops
    [SerializeField] float shrinkDuration = 3f;  // Duration to scale John down

    private bool hasTransformed = false;  // To ensure John scales only once
    private bool shouldMoveLibrarian = false;  // To ensure Librarian starts moving after John scales down
    private PlayerController johnMovementScript;  // Reference to John's movement script

    void Start()
    {
        // Get the movement script component from John's GameObject
        johnMovementScript = johnTransform.GetComponent<PlayerController>();

        // Subscribe to the countdown timeout event
        countdown.OnTimeout += HandleTimeout;

        // Ensure LoseDialogue is hidden at the start
        loseDialogue.SetActive(false);
    }

    void Update()
    {
        if (shouldMoveLibrarian)
        {
            MoveLibrarianTowardsJohn();
        }
    }

    // Method to handle the events when the countdown reaches zero
    private void HandleTimeout()
    {
        if (!hasTransformed)
        {
            johnMovementScript.DisableMovement();  // Disable John's movement
            StartCoroutine(ShrinkJohn());  // Start shrinking John
            shouldMoveLibrarian = true;  // Start moving the Librarian towards John
            librarianAnimator.SetBool("isWalking", true);
            hasTransformed = true;

            // Define the position and rotation for the book
            Vector3 bookPosition = new Vector3(johnTransform.position.x, 0.5f, johnTransform.position.z);
            Quaternion bookRotation = Quaternion.Euler(-30f, 0.28f, -90);

            // Spawn JohnBook at the adjusted position with the specified rotation
            GameObject johnBookInstance = Instantiate(johnBookPrefab, bookPosition, bookRotation);
            Camera.main.GetComponent<CameraFollow>().OnJohnBookAppeared();
        }
    }

    // Coroutine to shrink John over time
    private IEnumerator ShrinkJohn()
    {
        Vector3 originalScale = johnTransform.localScale;
        Vector3 targetScale = Vector3.zero;  // Scale John to 0, 0, 0
        float elapsedTime = 0f;

        while (elapsedTime < shrinkDuration)
        {
            elapsedTime += Time.deltaTime;
            float progress = elapsedTime / shrinkDuration;

            // Scale John down over time
            johnTransform.localScale = Vector3.Lerp(originalScale, targetScale, progress);

            yield return null;
        }

        // Ensure final scale is set to zero
        johnTransform.localScale = targetScale;
    }

    // Method to move the Librarian towards John's position
    private void MoveLibrarianTowardsJohn()
    {
        Vector3 direction = johnTransform.position - librarianTransform.position;  // Direction to John
        direction.y = 0;  // Keep the Librarian on the same plane (ignore Y-axis)

        // Check the distance to John
        float distance = direction.magnitude;

        if (distance > stopDistance)
        {
            direction.Normalize();  // Normalize direction to get a unit vector
            librarianTransform.position += direction * librarianSpeed * Time.deltaTime;  // Move Librarian

            Quaternion targetRotation = Quaternion.LookRotation(direction);
            librarianTransform.rotation = Quaternion.Slerp(librarianTransform.rotation, targetRotation, Time.deltaTime * 5f);
        }
        else
        {
            shouldMoveLibrarian = false;  // Stop moving once within stopDistance
            Destroy(johnTransform.gameObject, 0.5f);
            librarianAnimator.SetBool("isWalking", false);

            StartCoroutine(WaitAndDisplayLoseDialogue(2f));  // Wait for 2 seconds before showing the lose dialogue
        }
    }

    // Coroutine to wait for a delay before displaying the lose dialogue
    private IEnumerator WaitAndDisplayLoseDialogue(float delay)
    {
        yield return new WaitForSeconds(delay);
        DisplayLoseDialogue();
    }

    // Method to display the lose dialogue
    public void DisplayLoseDialogue()
    {
        loseDialogue.SetActive(true);
    }
}