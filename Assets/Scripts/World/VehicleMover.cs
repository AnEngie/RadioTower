using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class VehicleMover : MonoBehaviour
{
    public float moveSpeed = 8f;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector3(moveSpeed, rb.velocity.y, rb.velocity.z);
    }
}
