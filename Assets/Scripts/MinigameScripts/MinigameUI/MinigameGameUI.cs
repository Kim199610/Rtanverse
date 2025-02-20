using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MinigameGameUI : MinigameBaseUI
{
    
    public override void Init(MinigameUIManager UIManager)
    {
        base.Init(UIManager);

    }
    protected override UIState GetUIState()
    {
        return UIState.MinigameGame;
    }
    
    
}
