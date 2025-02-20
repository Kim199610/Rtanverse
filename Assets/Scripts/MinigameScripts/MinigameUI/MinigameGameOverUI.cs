using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MinigameGameOverUI : MinigameBaseUI
{
    [SerializeField] Button restartButton;
    [SerializeField] Button exitMiniGameButton;
    [SerializeField] Button toMainButton;
    public override void Init(MinigameUIManager UIManager)
    {
        base.Init(UIManager);

        restartButton.onClick.AddListener(OnClickRestartButton);
        exitMiniGameButton.onClick.AddListener(OnClickExitMiniGameButton);
        toMainButton.onClick.AddListener(OnClickToMainButton);
    }
    protected override UIState GetUIState()
    {
        return UIState.MinigameGameOver;
    }
    public void OnClickRestartButton()
    {
        MinigameManager.Instance.RestartGame();
    }
    public void OnClickExitMiniGameButton()
    {
        MinigameManager.Instance.ExitMinigame();
    }
    public void OnClickToMainButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
