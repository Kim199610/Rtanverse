using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameManager : MonoBehaviour
{
    static MinigameManager minigameManager;
    public MinigameUIManager minigameUIManager;
    public static MinigameManager Instance
    {
        get { return minigameManager;}
    }
    public MinigameBgLooper minigameBgLooper;
    public Minigame_Player minigame_Player;

    public int currentScore = 0;
    float delayTime = 3f;
    int bestScore;

    public static bool isRestart=false;

    private void Awake()
    {
        
        minigameManager = this;
        minigameBgLooper.SettingObstacleInStart();
        minigameUIManager = FindObjectOfType<MinigameUIManager>(true);
        
        Time.timeScale = 0f;
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        
        PlayerPrefs.Save();
    }

    private void Start()
    {
        if (isRestart)
        {
            GameStart();
            isRestart = false;
        }
    }
    private void Update()
    {
        delayTime = delayTime > 0 ? delayTime - Time.deltaTime : 0;
        minigameUIManager.UpdateDelayTime(delayTime);

        if((minigame_Player.GetComponent<Rigidbody2D>()).constraints.HasFlag(RigidbodyConstraints2D.FreezeAll) && delayTime == 0)
        {
            (minigame_Player.GetComponent<Rigidbody2D>()).constraints = RigidbodyConstraints2D.None;
            
        }
    }

    public void GameStart()
    {
        PlayerPrefs.SetInt("MinigamePlayCount", PlayerPrefs.GetInt("MinigamePlayCount",0) + 1);
        PlayerPrefs.Save();
        minigameUIManager.ChangeState(UIState.MinigameGame);
        currentScore = 0;
        minigameUIManager.UpdateScore(currentScore);
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
        minigameUIManager.UpdateBestScore(bestScore);


        (minigame_Player.GetComponent<Rigidbody2D>()).constraints = RigidbodyConstraints2D.FreezeAll;
        
        delayTime = 3f;
        (GameObject.Find("UI")).transform.Find("GameUI/DelayTime").gameObject.SetActive(true);

        Time.timeScale = 1f;

        
        
    }
    public void GameOver()
    {
        minigameUIManager.UpdateResultScore(currentScore);
        minigameUIManager.UpdateResultBestScore(currentScore, bestScore);

        if (PlayerPrefs.GetInt("CurrentBestScore", 0) < currentScore)
        {
            PlayerPrefs.SetInt("CurrentBestScore",currentScore);
            PlayerPrefs.Save();
        }

        minigameUIManager.ChangeState(UIState.MinigameGameOver);
    }
    public void RestartGame()
    {
        isRestart = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void AddScore(int score)
    {
        currentScore += score;
        minigameUIManager.UpdateScore(currentScore);
    }

    public void ExitMinigame()
    {
        PlayerPrefs.SetInt("IsMinigameEnd", 1);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Overworld");
    }
}
