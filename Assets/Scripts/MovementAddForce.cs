using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAddForce : MonoBehaviour
{
    [Header("Velocity info")]
    [SerializeField] private float playerVelocity;
    [Header("Varibles")]
    [SerializeField] private float movementSpeed = 200f;
    [SerializeField] private float maxSpeed = 200f;
    private float currentSpeed;
    private float speedSmoothVelocity;
    private Rigidbody2D rBody;

    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), 0);
        rBody.AddForce(input * movementSpeed);

        if (rBody.velocity.x < maxSpeed)
            rBody.AddForce(input * movementSpeed);

        playerVelocity = rBody.velocity.x;
    }
}
