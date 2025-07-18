using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 8f;
    public float moveSpeed;
    public bool facingRight = true;

    private static PlayerController Instance;

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

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = walkSpeed;
    }

    private void Start()
    {
        Instance = this;   
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * moveSpeed, rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;

        if (Instance.enabled == true)
            SwitchFacingDirection(moveInput);
    }

    private void SwitchFacingDirection(Vector2 moveInput)
    {
        if (moveInput.x > 0 && !facingRight)
        {
            facingRight = true;
            transform.localScale *= new Vector2(-1, 1);
        }
        else if (moveInput.x < 0 && facingRight)
        {
            facingRight = false;
            transform.localScale *= new Vector2(-1, 1);
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
