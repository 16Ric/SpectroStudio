using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public SceneTransition sceneTransition;
    private bool isPaused = false;

    void Start()
    {
        // Optionally, you can start the game in a paused state or not
    }

    void Update()
    {
        // Check if the player presses the Escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame(); // Resume the game if currently paused
            }
            else
            {
                PauseGame(); // Pause the game if currently playing
            }
        }
    }

    private void PauseGame()
    {
        isPaused = true;
        sceneTransition.GotoPauseScene(0f); // Transition to the Pause scene
        Time.timeScale = 0; // Optionally, stop the game time
    }

    private void ResumeGame()
    {
        isPaused = false;
        // Transition back to the last active scene
        sceneTransition.GotoGameScene(0f); // Adjust this to your method for going back to the previous scene
        Time.timeScale = 1; // Resume the game time
    }
}
