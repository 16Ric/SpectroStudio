using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public Transform librarian; // Reference to the librarian's transform
    public Vector3 offset;   // Offset position from the player
    public float zoomDuration = 2f; // Duration for the zoom effect
    public float targetFOV = 30f; // Target FOV for the zoom
    private Camera mainCamera;
    private bool isZooming = false;
    public GameController gameController; // Reference to the GameController

    void Start()
    {
        mainCamera = GetComponent<Camera>();
        offset = transform.position - player.position;
    }

    void LateUpdate()
    {
        if (player != null && !isZooming)
        {
            transform.position = player.position + offset;
        }
    }

    // This method will be called when the JohnBook is instantiated
    public void OnJohnBookAppeared()
    {
        if (!isZooming)
        {
            StartCoroutine(ZoomMoveAndRotateCamera());
        }
    }

    IEnumerator ZoomMoveAndRotateCamera()
    {
        isZooming = true;
        float startFOV = mainCamera.fieldOfView;
        Vector3 startPos = transform.position;
        Vector3 targetPos = new Vector3(startPos.x, startPos.y - 4f, startPos.z + 4f);
        Quaternion startRot = transform.rotation;
        float elapsed = 0f;

        // Zoom and move down
        while (elapsed < zoomDuration)
        {
            elapsed += Time.deltaTime;
            mainCamera.fieldOfView = Mathf.Lerp(startFOV, targetFOV, elapsed / zoomDuration);
            transform.position = Vector3.Lerp(startPos, targetPos, elapsed / zoomDuration);
            yield return null;
        }

        // Ensure the target FOV and position are set after zooming is complete
        mainCamera.fieldOfView = targetFOV;
        transform.position = targetPos;

        // Wait for 2 seconds
        yield return new WaitForSeconds(2f);

        // Move the camera's Y-coordinate back up by +4 units
        Vector3 finalPos = new Vector3(targetPos.x, targetPos.y + 4f, targetPos.z);
        elapsed = 0f;

        while (elapsed < zoomDuration)
        {
            elapsed += Time.deltaTime;
            transform.position = Vector3.Lerp(targetPos, finalPos, elapsed / zoomDuration);
            yield return null;
        }

        // Ensure the final position is set after moving back up
        transform.position = finalPos;

        // Rotate the camera by -8 degrees around the Y-axis
        Quaternion targetRot = startRot * Quaternion.Euler(0, -8f, 0);
        elapsed = 0f;

        while (elapsed < zoomDuration)
        {
            elapsed += Time.deltaTime;
            //transform.rotation = Quaternion.Slerp(startRot, targetRot, elapsed / zoomDuration);
            yield return null;
        }

        // Ensure the final rotation is set
        // transform.rotation = targetRot;

        // Wait for 1 second before panning to the librarian's face
        yield return new WaitForSeconds(1f);
    }
}
