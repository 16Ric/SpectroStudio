using System.Collections;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    private Animator animator;
    private PlayerController playerController;
    private Vector3 targetPosition = new Vector3(-5f, 0f, -20f); // John's target position

    // Speed of John's animation
    public float moveSpeed = 2f;

    void Start()
    {
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();

        // Temporarily disable the PlayerController control for 3 seconds and move John
        if (playerController != null)
        {
            StartCoroutine(DisablePlayerControllerTemporarily(3f));
        }

        // Set isRunning to true
        animator.SetBool("isRunning", true);
        animator.SetBool("isTakeBook", false);
    }

    // Coroutine to disable PlayerController and optionally show game component after a specific duration
    private IEnumerator DisablePlayerControllerTemporarily(float duration)
    {
        // Disable the PlayerController script
        playerController.enabled = false;

        // Move John towards the target position over the specified duration
        float elapsedTime = 0f;
        Vector3 startingPosition = transform.position;

        while (elapsedTime < duration)
        {
            transform.position = Vector3.Lerp(startingPosition, targetPosition, (elapsedTime / duration));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Make sure John reaches the exact target position after the movement
        transform.position = targetPosition;

        // Re-enable the PlayerController script
        playerController.enabled = true;

        // Stop the running animation
        animator.SetBool("isRunning", false);
    }
}
