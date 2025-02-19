using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : BaseController
{
    private Camera camera;

    protected override void Start()
    {
        base.Start();
        camera = Camera.main;
    }

    protected override void HandleAction()
    {
        

        Vector2 mousePosition = Input.mousePosition;
        Vector2 worldPos = camera.ScreenToWorldPoint(mousePosition);
        lookDirection = (worldPos - (Vector2)transform.position);

        if (lookDirection.magnitude < 0.9f)
        {
            lookDirection = Vector2.zero;
        }
        else
        {
            lookDirection = lookDirection.normalized;
        }
    }

    void OnMove(InputValue inputValue)
    {
        movementDirection = inputValue.Get<Vector2>();
        movementDirection = movementDirection.normalized;
    }
    void OnLook()
    {

    }
    void OnFire()
    {

    }
}
