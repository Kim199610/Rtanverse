using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MinigameNPCController : MonoBehaviour
{
    private GameObject AskMinigameMassage;
    [SerializeField] Button playMinigameButton;
    Animator animator;

    private void Awake()
    {
        AskMinigameMassage = transform.Find("AskMinigame").gameObject;
        AskMinigameMassage.SetActive(false);
        animator = GetComponentInChildren<Animator>();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Player"))
        {
            AskMinigameMassage.SetActive(true);
            playMinigameButton.onClick.AddListener(PlayMinigameScene);
            animator.SetBool("IsTalk",true);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        AskMinigameMassage.SetActive(false);
        animator.SetBool("IsTalk", false);
    }
    private void PlayMinigameScene()
    {
        SceneManager.LoadScene("MiniGameScene");
    }
}
