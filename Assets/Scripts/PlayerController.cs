using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f; // Speed of the character movement
    private Animator animator;
    private Rigidbody rb;
    private Quaternion targetRotation;
    private bool canMove = true;  // Flag to control movement
    private bool allowRunningControl = true;  // New flag to control isRunning externally

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>(); // Get the Animator component
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
        targetRotation = transform.rotation; // Initialize the target rotation to the current rotation
    }

    // Update is called once per frame
    void Update()
    {
        // Check if movement is allowed
        if (!canMove)
        {
            // If not allowed, stop the animation
            animator.SetBool("isRunning", false);
            return;  // Exit the Update method
        }

        // Get the input from the WASD keys
        float moveHorizontal = Input.GetAxis("Horizontal"); // A and D keys
        float moveVertical = Input.GetAxis("Vertical");     // W and S keys

        // Create a movement vector
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical).normalized * speed * Time.deltaTime;

        // Apply the movement using the Rigidbody
        rb.MovePosition(transform.position + movement);

        // Check if the character is moving
        bool isMoving = movement.magnitude > 0;

        // Update the Animator's isRunning parameter only if allowed
        if (allowRunningControl)
        {
            animator.SetBool("isRunning", isMoving);
        }

        // Rotate the character based on key input
        if (Input.GetKeyDown(KeyCode.D))
        {
            targetRotation = Quaternion.Euler(0, 90, 0);
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            targetRotation = Quaternion.Euler(0, -90, 0);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            targetRotation = Quaternion.Euler(0, 180, 0);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            targetRotation = Quaternion.Euler(0, 0, 0);
        }

        // Smoothly rotate the character to the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
    }

    // Method to disable movement
    public void DisableMovement()
    {
        canMove = false;
    }

    // Method to control external setting of isRunning
    public void AllowRunningControl(bool allow)
    {
        allowRunningControl = allow;
    }
}
