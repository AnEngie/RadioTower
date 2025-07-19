using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class VehicleMover : MonoBehaviour
{
    public float activeTime = 1f;
    public float moveSpeed = 8f;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(DisableAfter());
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
    }

    IEnumerator DisableAfter()
    {
        yield return new WaitForSeconds(activeTime);
        gameObject.SetActive(false);
    }
}
