using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoAcceleration : MonoBehaviour
{
    public float acceleration = 1f;
    public float topVelocity = 10f;
    public float brakeDeceleration = 1f;
    private bool isBraking = false;

    private Rigidbody2D rb;
    private Vector2 velocity;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void BrakeButton()
    {
        if (!isBraking)
        {
            isBraking = true;
        }
    }
    private void FixedUpdate()
    {
        velocity = rb.velocity + acceleration * Time.fixedDeltaTime * Vector2.right;

        velocity.x = Mathf.Min(velocity.x, topVelocity);

        if (isBraking)
            {
            velocity.x -= brakeDeceleration * Time.fixedDeltaTime;
            velocity.x = Mathf.Max(velocity.x, 0);
        }

        rb.velocity = velocity;
    }
}