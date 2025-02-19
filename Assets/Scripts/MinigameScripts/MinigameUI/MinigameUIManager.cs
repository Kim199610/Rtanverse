using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.XR;

public enum UIState
{
    MinigameStart,
    MinigameGameOver,
    MinigameScore,
    MinigameGame
}
public class MinigameUIManager : MonoBehaviour
{
    MinigameStartUI minigameStartUI;
    MinigameScoreUI minigameScoreUI;
    MinigameGameOverUI minigameGameOverUI;
    MinigameGameUI minigameGameUI;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI delayTimeText;

    public MinigameManager minigameManager;
    

    private UIState currentState;


    private void Awake()
    {
        minigameStartUI = GetComponentInChildren<MinigameStartUI>(true);
        minigameStartUI.Init(this);
        minigameGameOverUI = GetComponentInChildren<MinigameGameOverUI>(true);
        minigameGameOverUI.Init(this);
        minigameScoreUI = GetComponentInChildren<MinigameScoreUI>(true);
        minigameScoreUI.Init(this);
        minigameGameUI = GetComponentInChildren<MinigameGameUI>(true);
        minigameGameUI.Init(this);

        ChangeState(UIState.MinigameStart);
    }
    public void ChangeState(UIState state)
    {
        currentState = state;
        minigameStartUI.SetActive(currentState);
        minigameGameUI.SetActive(currentState);
        minigameScoreUI.SetActive(currentState);
        minigameGameOverUI.SetActive(currentState);

    }
    public void UpdateScore(int score)
    {
        scoreText.text = score.ToString();
    }
    public void UpdateDelayTime(float delayTime)
    {
        delayTimeText.text = ((int)Mathf.Ceil(delayTime)).ToString();
        if(delayTime == 0)
        {
            Transform delayTimeCanvers = transform.Find("GameUI/DelayTime");
            delayTimeCanvers.gameObject.SetActive(false);
        }
    }
}
