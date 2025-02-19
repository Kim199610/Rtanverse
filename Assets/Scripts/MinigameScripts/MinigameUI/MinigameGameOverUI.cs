using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MinigameGameOverUI : MinigameBaseUI
{
    [SerializeField] Button restartButton;
    [SerializeField] Button toMainButton;
    public override void Init(MinigameUIManager UIManager)
    {
        base.Init(UIManager);

        restartButton.onClick.AddListener(OnClickRestartButton);
    }
    protected override UIState GetUIState()
    {
        return UIState.MinigameGameOver;
    }
    public void OnClickRestartButton()
    {
        MinigameManager.Instance.RestartGame();
    }

}
