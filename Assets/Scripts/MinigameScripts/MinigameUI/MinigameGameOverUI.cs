using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MinigameGameOverUI : MinigameBaseUI
{
    [SerializeField] Button restartButton;
    [SerializeField] Button exitMiniGameButton;
    public override void Init(MinigameUIManager UIManager)
    {
        base.Init(UIManager);

        restartButton.onClick.AddListener(OnClickRestartButton);
        exitMiniGameButton.onClick.AddListener(OnClickExitMiniGameButton);
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
}
