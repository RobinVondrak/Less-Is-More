using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    PlayerJump playerJump;
    void Start()
    {
        playerJump = transform.parent.GetComponent<PlayerJump>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject != playerJump.gameObject) 
            playerJump.FloorHit(transform.position);
    }
}
