public class SceneTransition : GameManagerClient
{
    public void GotoGameScene1(float delay = 0f)
    {
        StartCoroutine(GameManager.GotoScene(GameManager.GameScene1Name, delay));
    }

    public void GotoGameScene2(float delay = 0f)
    {
        StartCoroutine(GameManager.GotoScene(GameManager.GameScene2Name, delay));
    }

    public void GotoGameScene3(float delay = 0f)
    {
        StartCoroutine(GameManager.GotoScene(GameManager.GameScene3Name, delay));
    }

    public void GotoMenuScene(float delay = 0f)
    {
        StartCoroutine(GameManager.GotoScene(GameManager.MenuSceneName, delay));
    }

    public void GotoGameOverScene(float delay = 5f)
    {
        StartCoroutine(GameManager.GotoScene(GameManager.GameOverSceneName, 10f));
    }

    public void GotoPauseScene(float delay = 0f)
    {
        StartCoroutine(GameManager.GotoScene(GameManager.PauseSceneName, delay));
    }

    public void GotoGameScene(float delay = 0f)
    {
        StartCoroutine(GameManager.GotoScene(GameManager.CurrentGameSceneName, delay));
    }

    public void GotoCreditScene(float delay = 0f)
    {
        StartCoroutine(GameManager.GotoScene(GameManager.CreditSceneName, delay));
    }

}