using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MinigameStartUI : MinigameBaseUI
{
    [SerializeField] Button startButton;
    [SerializeField] Button howToButton;
    [SerializeField] Button exitButton;

    public override void Init(MinigameUIManager UIManager)
    {
        base.Init(UIManager);
        startButton.onClick.AddListener(OnClickStartButton);
        howToButton.onClick.AddListener(OnClickHowToButton);
        exitButton.onClick.AddListener(OnClickExitButton);
    }
    protected override UIState GetUIState()
    {
        return UIState.MinigameStart;
    }

    public void OnClickStartButton()
    {
        Debug.Log("clicked");
        MinigameManager.Instance.GameStart();
    }
    public void OnClickHowToButton()
    {
        MinigameManager.Instance.minigameUIManager.ChangeState(UIState.MinigameHowTo);
    }
    public void OnClickExitButton()
    {
        MinigameManager.Instance.ExitMinigame();
    }
}
