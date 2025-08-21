using UnityEngine;

public class CorrectSymbolManager : MonoBehaviour
{
    public static CorrectSymbolManager Instance;

    // Example symbols that need to be activated
    public GameObject symbol1;
    public GameObject symbol2;
    public GameObject symbol3;

    // Reference to the parent PuzzleTemplate GameObject
    public GameObject puzzleTemplate;

    // Reference to the particle system for the ghost swirl effect
    public ParticleSystem ghostSwirlParticles;  // Drag and drop the ghost swirl particle system in the Inspector

    private bool puzzleDestroyed = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);  // Keeps the instance alive across different scenes
        }
        else
        {
            Destroy(gameObject);  // Ensures that there is only one instance of this object
        }
    }

    void Start()
    {
        // Set the puzzle template and symbols inactive at the start
        if (puzzleTemplate != null)
        {
            puzzleTemplate.SetActive(false);
        }

        // Ensure the ghost swirl particles are not playing at the start
        if (ghostSwirlParticles != null)
        {
            ghostSwirlParticles.Stop();
        }
    }

    void Update()
    {
        // Continuously check if all symbols are activated
        if (!puzzleDestroyed && AreAllSymbolsActivated())
        {
            DestroyPuzzleTemplate();
            puzzleDestroyed = true; // Ensure the puzzle is destroyed only once
            TriggerSwirlEffect();  // Trigger the ghost swirl effect
        }
    }

    // Public method to check if all symbols have been activated
    public bool AreAllSymbolsActivated()
    {
        return symbol1.activeSelf && symbol2.activeSelf && symbol3.activeSelf;
    }

    // Method to destroy the parent PuzzleTemplate GameObject
    private void DestroyPuzzleTemplate()
    {
        if (puzzleTemplate != null)
        {
            Destroy(puzzleTemplate);  // Destroy the puzzle template
            Debug.Log("PuzzleTemplate has been destroyed.");
        }
        else
        {
            Debug.LogWarning("PuzzleTemplate reference is missing.");
        }
    }

    // Method to trigger the ghost swirl effect
    private void TriggerSwirlEffect()
    {
        if (ghostSwirlParticles != null)
        {
            ghostSwirlParticles.Play();  // Start the ghost swirl particle effect
            Debug.Log("Ghost swirl effect triggered.");
        }
        else
        {
            Debug.LogWarning("Ghost swirl particle system is not assigned.");
        }
    }
}
