using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldGameManager : MonoBehaviour
{
    public static OverworldGameManager Instance { get; private set; }
    public MinigameNPCController minigameNPC;
    public PlayerController PlayerController;

    private void Awake()
    {
        Time.timeScale = 1.0f;
        if (Instance == null)
            Instance = this;
        else
        { Destroy(gameObject); return; }
    }

    

    private void Start()
    {
        if (PlayerPrefs.GetInt("IsMinigameEnd") == 1)
        {
            PlayerController.transform.position = new Vector3(-6.5f, -3f, 0);
            minigameNPC.resultMessageOn();

            PlayerPrefs.SetInt("IsMinigameEnd", 0);
        }
    }

}
