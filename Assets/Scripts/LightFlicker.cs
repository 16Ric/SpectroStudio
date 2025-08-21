using System.Collections;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light flickerLight;  // Assign your spotlight here
    public float minIntensity = 4000f;  // Minimum intensity for flicker
    public float maxIntensity = 5000f;  // Maximum intensity for flicker
    public float minFlickerSpeed = 0.05f;  // Minimum flicker speed (fast flicker)
    public float maxFlickerSpeed = 0.2f;  // Maximum flicker speed (slow flicker)

    private float targetIntensity;

    void Start()
    {
        if (flickerLight == null)
        {
            flickerLight = GetComponent<Light>();
        }

        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        while (true)
        {
            // Randomly choose the next flicker intensity
            targetIntensity = Random.Range(minIntensity, maxIntensity);

            // Smoothly transition to the new intensity
            flickerLight.intensity = Mathf.Lerp(flickerLight.intensity, targetIntensity, Time.deltaTime * 10f);

            // Wait for a random time before flickering again
            yield return new WaitForSeconds(Random.Range(minFlickerSpeed, maxFlickerSpeed));
        }
    }
}
