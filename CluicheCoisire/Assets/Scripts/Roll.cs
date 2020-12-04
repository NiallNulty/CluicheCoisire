using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
    public float speed = 10F;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 acc = Input.acceleration;
        rb.AddForce(acc.x * speed, 0, acc.y * speed);
    }
}
