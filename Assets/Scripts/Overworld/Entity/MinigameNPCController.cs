using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MinigameNPCController : BaseNPCController
{
    [SerializeField] TextMeshProUGUI minigameBestScoreIntText;
    [SerializeField] TextMeshProUGUI minigameResultText;
    [SerializeField] GameObject resultMessageObject;
    [SerializeField] Button resultMessageButton;
    private void Start()
    {
        minigameBestScoreIntText.text = PlayerPrefs.GetInt("BestScore").ToString();

    }
    protected override void OnTriggerStay2D(Collider2D collision)
    {
        base.OnTriggerStay2D(collision);
        resultMessageButton.onClick.AddListener(OnClickInResultMessageButton);
    }
    protected override void OnTriggerExit2D(Collider2D collision)
    {
        base.OnTriggerExit2D(collision);
        resultMessageObject.SetActive(false);
    }
    protected override void OnClickInMassageButton()
    {
        PlayerPrefs.SetInt("MinigamePlayCount", 0);
        PlayerPrefs.SetInt("NewBestScore", 0);
        PlayerPrefs.SetInt("CurrentBestScore", 0);
        PlayerPrefs.Save();
        SceneManager.LoadScene("MiniGameScene");
    }
    private void OnClickInResultMessageButton()
    {
        resultMessageObject.SetActive(false);
    }
    public void resultMessageOn()
    {
        minigameResultText.text = $"게임결과\n\n총 {PlayerPrefs.GetInt("MinigamePlayCount", 0)}회 플레이\n\n이번게임 최고점수\n{PlayerPrefs.GetInt("CurrentBestScore", 0),3} 점 " + (PlayerPrefs.GetInt("NewBestScore") == 1 ? "[최고기록 갱신!]" : "") + $"\n\n최고점수\n{PlayerPrefs.GetInt("BestScore")}";
        resultMessageObject.SetActive(true);
    }
}
