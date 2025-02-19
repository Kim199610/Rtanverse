using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameScoreUI : MinigameBaseUI
{
    public override void Init(MinigameUIManager UIManager)
    {
        base.Init(UIManager);


    }
    protected override UIState GetUIState()
    {
        return UIState.MinigameScore;
    }
}
