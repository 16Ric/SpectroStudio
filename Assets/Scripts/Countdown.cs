using System.Collections;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] private float remainingTime;
    public SceneTransition sceneTransition;
    public float sceneTransitionDelay = 0.5f;

    public event System.Action OnTimeout;

    void Update()
    {
        if (remainingTime > 0)
        {
            remainingTime -= Time.deltaTime;
        }

        remainingTime = Mathf.Max(remainingTime, 0);

        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if (remainingTime == 0)
        {
            timerText.color = Color.red;
            //timerText.enabled = false;
            OnTimeout?.Invoke();
            sceneTransition.GotoGameOverScene(sceneTransitionDelay);
        }
    }

    public void ReduceTime(float reductionAmount)
    {
        remainingTime -= reductionAmount;
        remainingTime = Mathf.Max(remainingTime, 0);
    }

    public void SetRemainingTime(float time)
    {
        remainingTime = time;
    }


    public float GetRemainingTime()
    {
        return remainingTime;
    }
}
