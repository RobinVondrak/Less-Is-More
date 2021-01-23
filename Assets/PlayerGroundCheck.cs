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
        playerJump.FloorHit(transform.position);
    }
}
