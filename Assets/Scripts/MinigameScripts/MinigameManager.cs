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
    
    private void Awake()
    {
        minigameManager = this;
        minigameBgLooper.SettingObstacleInStart();
        minigameUIManager = FindObjectOfType<MinigameUIManager>(true);
        
        Time.timeScale = 0f;
        bestScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    private void Start()
    {
        
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
        minigameUIManager.ChangeState(UIState.MinigameGameOver);

    }
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void AddScore(int score)
    {
        currentScore += score;
        minigameUIManager.UpdateScore(currentScore);
    }

    public void ExitMinigame()
    {
        SceneManager.LoadScene("Overworld");
    }
}
