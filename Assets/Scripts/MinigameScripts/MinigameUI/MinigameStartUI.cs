using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class MinigameStartUI : MinigameBaseUI
{
    [SerializeField] Button startButton;

    public override void Init(MinigameUIManager UIManager)
    {
        base.Init(UIManager);
        startButton.onClick.AddListener(OnClickStartButton);
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
}
