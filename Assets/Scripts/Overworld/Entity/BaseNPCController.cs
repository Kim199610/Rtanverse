using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BaseNPCController : MonoBehaviour
{
    [SerializeField]protected GameObject messageCanvas;
    [SerializeField]protected GameObject basicMassage;
    [SerializeField]protected Button basicMassageButton;
    Animator animator;

    protected virtual void Awake()
    {
        messageCanvas = GetComponentInChildren<Canvas>(true).gameObject;
        basicMassage = FindChildWithTag(messageCanvas, "basicMessage");
        basicMassageButton = basicMassage.GetComponentInChildren<Button>(true);
        basicMassage.SetActive(false);
        messageCanvas.SetActive(false);
        animator = GetComponentInChildren<Animator>();
    }
    protected virtual void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            messageCanvas.SetActive(true);
    }
    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            messageCanvas.SetActive(false);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Player"))
        {
            basicMassage.SetActive(true);
            basicMassageButton.onClick.AddListener(OnClickInBasicMassageButton);
            animator.SetBool("IsTalk", true);
        }
    }
    protected virtual void OnCollisionExit2D(Collision2D collision)
    {
        basicMassage.SetActive(false);
        animator.SetBool("IsTalk", false);
    }
    protected virtual void OnClickInBasicMassageButton()
    {

    }

    protected GameObject FindChildWithTag(GameObject parent, string tag)
    {
        foreach (Transform child in parent.transform)
        {
            if (child.CompareTag(tag))
            {
                return child.gameObject; 
            }
        }
        return null; 
    }
   
}
