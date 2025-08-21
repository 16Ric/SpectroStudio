using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(SceneManager))]
public class GameManager : MonoBehaviour
{
    public const string Tag = "GameManager";

    public static string CurrentGameSceneName { get; private set; } // Store the name of the current game scene
    public const string MenuSceneName = "StartScene";
    public const string GameScene1Name = "Stage1Scene";
    public const string GameScene2Name = "Stage2Scene";
    public const string GameScene3Name = "Stage3Scene";
    public const string GameOverSceneName = "GameOverScene";
    public const string PauseSceneName = "PauseScene";
    public const string CreditSceneName = "CreditScene";

    private void Awake()
    {
        // Should not be created if there's already a manager present (at least
        // two total, including ourselves). This allows us to place a game
        // manager in every scene, in case we want to open scenes direct.
        if (GameObject.FindGameObjectsWithTag(Tag).Length > 1)
            Destroy(gameObject);

        // Hook into scene loaded events.
        SceneManager.sceneLoaded += OnSceneLoaded;

    }

    public IEnumerator GotoScene(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);

        var asyncLoadOp = SceneManager.LoadSceneAsync(sceneName);
        CurrentGameSceneName = sceneName;
        while (!asyncLoadOp.isDone)
        {
            yield return null;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

    }
}