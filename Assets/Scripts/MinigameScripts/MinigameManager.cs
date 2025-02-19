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
    MinigameUIManager minigameUIManager;
    public static MinigameManager Instance
    {
        get { return minigameManager;}
    }
    public MinigameBgLooper minigameBgLooper;
    public Minigame_Player minigame_Player;

    int currentScore = 0;
    float delayTime = 3f;
    Rigidbody2D playerRigidbody;
    private void Awake()
    {
        minigameManager = this;
        minigameBgLooper.SettingObstacleInStart();
        minigameUIManager = FindObjectOfType<MinigameUIManager>(true);
        playerRigidbody = minigame_Player.GetComponent<Rigidbody2D>();
        Time.timeScale = 0f;
    }

    private void Start()
    {
        
    }
    private void Update()
    {
        delayTime = delayTime > 0 ? delayTime - Time.deltaTime : 0;
        minigameUIManager.UpdateDelayTime(delayTime);

        if(playerRigidbody.constraints.HasFlag(RigidbodyConstraints2D.FreezeAll) && delayTime == 0)
        {
            playerRigidbody.constraints = RigidbodyConstraints2D.None;
            
        }
    }

    public void GameStart()
    {
        
        minigameUIManager.ChangeState(UIState.MinigameGame);
        currentScore = 0;
        minigameUIManager.UpdateScore(currentScore);

        minigame_Player.transform.position = Vector3.zero;
        playerRigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
        
        delayTime = 3f;
        Transform delayTimeCanvers = (GameObject.Find("UI")).transform.Find("GameUI/DelayTime");
        delayTimeCanvers.gameObject.SetActive(true);

        Time.timeScale = 1f;

        
        
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
        minigameUIManager.UpdateScore(currentScore);
    }
}
