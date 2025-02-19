using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline;
using UnityEngine;

public abstract class MinigameBaseUI : MonoBehaviour
{
    protected MinigameUIManager UIManager; 

    public virtual void Init(MinigameUIManager UIManager)
    {
        this.UIManager = UIManager;
    }
    protected abstract UIState GetUIState();

    public void SetActive(UIState state)
    {
        this.gameObject.SetActive(GetUIState() == state);
    }
}
