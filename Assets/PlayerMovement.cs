using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float startSpeed = 2;
    [SerializeField] private float runSpeed = 8;
    float currentSpeed;
    float speedSmoothVelocity;
    
    Vector3 force;
    Rigidbody2D rb;

    public AppleManager appleManager;

    void Awake()
    {
        if (appleManager == null)
            appleManager = GetComponent<AppleManager>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        Vector3 input = new Vector3(x, 0, 0);

        bool running = Input.GetKey(KeyCode.LeftShift);
        float targetSpeed = ((running) ? runSpeed + appleManager.charachterAppleLossBoost() : startSpeed + appleManager.charachterAppleLossBoost()) * input.magnitude;
        
        currentSpeed = Mathf.SmoothDamp(currentSpeed, targetSpeed, ref speedSmoothVelocity, 0.3f);
        
        force = input * currentSpeed;
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(force.x, rb.velocity.y);
    }
}
