using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(SpriteRenderer))]
public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 8f;
    public float moveSpeed;

    Vector2 moveInput;

    [SerializeField]
    private bool _isMoving = false;

    public bool IsMoving
    {
        get
        {
            return _isMoving;
        }
        set
        {
            _isMoving = value;
        }
    }

    [SerializeField]
    private bool _isRunning = false;

    public bool IsRunning
    {
        get
        {
            return _isRunning;
        }
        set
        {
            _isRunning = value;
        }
    }

    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        moveSpeed = walkSpeed;
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;

        if (isActiveAndEnabled && Time.timeScale != 0)
            SwitchFacingDirection(moveInput);
    }

    private void SwitchFacingDirection(Vector2 moveInput)
    {
        switch (moveInput.x)
        {
            case > 0:
                spriteRenderer.flipX = false;
                break;
            case < 0:
                spriteRenderer.flipX = true;
                break;
        }
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            IsRunning = true;
            moveSpeed = runSpeed;
        }
        else if (context.canceled)
        {
            IsRunning = false;
            moveSpeed = walkSpeed;
        }
    }
}
