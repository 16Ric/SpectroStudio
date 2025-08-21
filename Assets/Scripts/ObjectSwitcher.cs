using UnityEngine;

public class ObjectSwitcher : MonoBehaviour
{
    // Assign these in the Unity Inspector
    public GameObject objectToDisable;  // The object to disable when clicked
    public GameObject objectToEnable;   // The object to enable when clicked

    // This function is triggered when the object is clicked
    private void OnMouseDown()
    {
        if (objectToDisable != null && objectToEnable != null)
        {
            // Enable the other object
            objectToEnable.SetActive(true);
            
            // Disable the current object
            objectToDisable.SetActive(false);
            
        }
    }
}
