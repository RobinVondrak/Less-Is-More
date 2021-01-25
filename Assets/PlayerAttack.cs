using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public PlayerAnimatorController playerAnimator;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            playerAnimator.Headbut();
    }
}
