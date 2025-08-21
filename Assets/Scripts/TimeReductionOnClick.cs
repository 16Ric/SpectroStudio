using UnityEngine;

public class TimerReductionOnClick : MonoBehaviour
{
    // Assign the Countdown script reference in the Unity Inspector
    public Countdown countdownScript;  // Reference to the Countdown script
    public float timeReduction = 10f;  // The amount of time to reduce from the timer when clicked

    // This function is triggered when the object is clicked
    private void OnMouseDown()
    {
        if (countdownScript != null)
        {
            // Reduce the remaining time
            countdownScript.ReduceTime(timeReduction);
            
            Debug.Log("Time reduced by " + timeReduction + " seconds.");
        }
        else
        {
            Debug.LogWarning("Countdown script reference is missing!");
        }
    }
}
