using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameGameOverUI : MinigameBaseUI
{
    public override void Init(MinigameUIManager UIManager)
    {
        base.Init(UIManager);
    }
    protected override UIState GetUIState()
    {
        return UIState.MinigameGameOver;
    }
}
