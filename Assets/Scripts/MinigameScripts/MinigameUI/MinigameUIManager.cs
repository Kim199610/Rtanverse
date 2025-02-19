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
    MinigameHowTo,
    MinigameGame
}
public class MinigameUIManager : MonoBehaviour
{
    MinigameStartUI minigameStartUI;
    MinigameHouToUI minigameHowtoUI;
    MinigameGameOverUI minigameGameOverUI;
    MinigameGameUI minigameGameUI;

    [SerializeField] TextMeshProUGUI delayTimeText;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI bestScoreText;
    [SerializeField] TextMeshProUGUI resultScoreText;
    [SerializeField] TextMeshProUGUI resultBestScoreText;

    public MinigameManager minigameManager;
    

    public UIState currentState;


    private void Awake()
    {
        minigameStartUI = GetComponentInChildren<MinigameStartUI>(true);
        minigameStartUI.Init(this);
        minigameGameOverUI = GetComponentInChildren<MinigameGameOverUI>(true);
        minigameGameOverUI.Init(this);
        minigameHowtoUI = GetComponentInChildren<MinigameHouToUI>(true);
        minigameHowtoUI.Init(this);
        minigameGameUI = GetComponentInChildren<MinigameGameUI>(true);
        minigameGameUI.Init(this);

        ChangeState(UIState.MinigameStart);
    }
    public void ChangeState(UIState state)
    {
        currentState = state;
        minigameStartUI.SetActive(currentState);
        minigameGameUI.SetActive(currentState);
        minigameHowtoUI.SetActive(currentState);
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
            transform.Find("GameUI/DelayTime").gameObject.SetActive(false);
        }
    }
    public void UpdateBestScore(int bestScore)
    {
        bestScoreText.text = bestScore.ToString();
    }

    public void UpdateResultScore(int score)
    {
        resultScoreText.text = score.ToString();
    }
    public void UpdateResultBestScore(int score, int bestScore)
    {
        if (score > bestScore)
        {
            bestScore = score;
            PlayerPrefs.SetInt("BestScore", bestScore);
            transform.Find("GameOverUI/NewRecord").gameObject.SetActive(true);
        }
        else
        {
            transform.Find("GameOverUI/NewRecord").gameObject.SetActive(false);
        }
        resultBestScoreText.text = bestScore.ToString();
    }
}
