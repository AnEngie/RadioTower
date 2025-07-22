using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SpriteRenderer))]
public class VehicleMover : MonoBehaviour
{
    public float moveSpeed = 8f;
    public int dir = 1;
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
                dir = -1;
                spriteRenderer.flipX = true;
                break;
            case < 0:
                dir = 1;
                spriteRenderer.flipX = false;
                break;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(dir * moveSpeed, rb.velocity.y, rb.velocity.z);
    }
}
