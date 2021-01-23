﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    Rigidbody2D rb;
    public float fallMulti = 2.5f;
    public float jumpForce;
    private bool canJump = true;
    public float maxVelocityY;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canJump)
        {
            canJump = false;
            Jump();
        }
        BetterFall();
        ClampYVelocity();
    }
    void Jump()
    {
        float force = Mathf.Abs(rb.velocity.y) + jumpForce;
        rb.AddForce(transform.up * force, ForceMode2D.Impulse);
    }
    void BetterFall()
    {
        if(rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMulti - 1) * Time.deltaTime;
        }
    }

    void ClampYVelocity()
    {
        var vel = rb.velocity;
        vel.y = Mathf.Clamp(vel.y, -maxVelocityY, maxVelocityY);
        rb.velocity = vel;
    }
    public void FloorHit(Vector3 particlePos)
    {
        canJump = true;
    }
}
