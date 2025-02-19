using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameHouToUI : MinigameBaseUI
{
    [SerializeField] Button exitHowToButton;
    public override void Init(MinigameUIManager UIManager)
    {
        base.Init(UIManager);

        exitHowToButton.onClick.AddListener(OnClickExitHowToButton);
    }
    protected override UIState GetUIState()
    {
        return UIState.MinigameHowTo;
    }

    public void OnClickExitHowToButton()
    {
        MinigameManager.Instance.minigameUIManager.ChangeState(UIState.MinigameStart);
    }
}
