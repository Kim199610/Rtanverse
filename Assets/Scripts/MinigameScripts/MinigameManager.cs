using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameManager : MonoBehaviour
{
    static MinigameManager minigameManager;
    public static MinigameManager Instance
    {
        get { return minigameManager;}
    }

    int currentScore = 0;

    private void Awake()
    {
        minigameManager = this;
    }
    public void GameOver()
    {
         
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void AddScore(int score)
    {
        currentScore += score;
    }
}
