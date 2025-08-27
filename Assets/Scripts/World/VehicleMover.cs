using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SpriteRenderer))]
public class VehicleMover : MonoBehaviour
{
    public float maxMoveSpeed = 8f;
    public float minMoveSpeed = 1f;
    private float moveSpeed;
    public float dir = 1;
    Rigidbody rb;
    SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        switch (gameObject.transform.position.x)
        {
            case > 0:
                moveSpeed = -Random.Range(minMoveSpeed, maxMoveSpeed);
                spriteRenderer.flipX = true;
                break;
            case < 0:
                moveSpeed = Random.Range(minMoveSpeed, maxMoveSpeed);
                spriteRenderer.flipX = false;
                break;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(moveSpeed, rb.velocity.y, rb.velocity.z);
    }
}
