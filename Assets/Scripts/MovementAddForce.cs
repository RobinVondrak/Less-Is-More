using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementAddForce : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5;
    [SerializeField] private float runSpeed = 8;
    [SerializeField] private float movementSpeed = 200f;
    private float maxSpeed = 200f;
    private float currentSpeed;
    private float speedSmoothVelocity;
    Rigidbody2D rBody;

    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 input = new Vector2(Input.GetAxis("Horizontal"), 0);
        rBody.AddForce(input * movementSpeed);

        if (rBody.velocity.magnitude > maxSpeed)
            rBody.velocity = Vector2.ClampMagnitude(rBody.velocity, maxSpeed);
    }
}
