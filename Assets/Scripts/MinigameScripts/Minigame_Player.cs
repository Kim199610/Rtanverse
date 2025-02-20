using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Minigame_Player : MonoBehaviour
{
    MinigameManager minigameManager;
    public MinigameUIManager minigameUIManager;

    Animator animator = null;
    Rigidbody2D _rigidbody = null;

    public float flyForce = 6f;
    public float forwardSpeed = 3f;
    public bool isDead = false;
    public float deathCooldown = 4f;
    public bool godMode = false;

    bool isFly = false;


    
    // Start is called before the first frame update
    void Start()
    {
        minigameManager = MinigameManager.Instance;
        animator = GetComponentInChildren<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            if (deathCooldown <= 0)
            {
                if(minigameUIManager.currentState != UIState.MinigameGameOver)
                    minigameManager.GameOver();
            }
            else
            {
                deathCooldown -= Time.deltaTime;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject())
                    return;
                isFly = true;
                animator.Play("Jump", 0, 0);
                
            }
        }
        forwardSpeed = 3f + (minigameManager.currentScore / 5) * 0.5f;
    }

    public void FixedUpdate()
    {
        if (isDead)
            return;

        Vector3 velocity = _rigidbody.velocity;
        velocity.x = forwardSpeed;

        if (isFly)
        {
            velocity.y += flyForce;
            isFly = false;
        }

        _rigidbody.velocity = velocity;


    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode)
            return;

        if (isDead)
            return;

        animator.SetBool("IsDie", true);
        isDead = true;
        deathCooldown = 1f;
    }
}

