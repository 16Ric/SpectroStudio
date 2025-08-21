using System.Collections;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public Countdown countdown; // Reference to the Countdown script
    public IEnumerator Shake(float duration, float magnitude)
    {
        Quaternion originalRotation = transform.localRotation;
        float elapsed = 0.0f;

        // Keep shaking the camera while the duration hasn't passed and the timer is not 0
        while (elapsed < duration && countdown.GetRemainingTime() > 0)
        {
            // Create random rotation values around the X, Y, and Z axes
            float x = Random.Range(-1f, 1f) * magnitude;
            float y = Random.Range(-1f, 1f) * magnitude;
            float z = Random.Range(-1f, 1f) * magnitude;

            // Apply the rotation to the camera
            transform.localRotation = Quaternion.Euler(
                originalRotation.eulerAngles.x + x,
                originalRotation.eulerAngles.y + y,
                originalRotation.eulerAngles.z + z
            );

            elapsed += Time.deltaTime;

            yield return null;
        }

        // Ensure the camera resets to its original rotation after the shake stops
        transform.localRotation = originalRotation;
    }
}
