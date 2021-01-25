using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorController : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void WalkingAnimation(bool isWalking)
    {
        animator.SetBool("IsWalking", isWalking);
    }
    public void Jump()
    {
        animator.SetTrigger("Jump");
    }
    public void Landed()
    {
        animator.SetTrigger("Landed");
    }
    public void Falling(float vel)
    {
        animator.SetFloat("VelocityY", vel);
    }
    public void Running(bool isRunning)
    {
        animator.SetBool("IsRunning", isRunning);
    }
    public void Headbut()
    {
        animator.SetTrigger("Headbut");
        StartCoroutine(oklart());
    }
    IEnumerator oklart()
    {
        animator.SetBool("HeadButting", true);
        yield return new WaitForSeconds(1f);
        animator.SetBool("HeadButting", false);
    }
}
