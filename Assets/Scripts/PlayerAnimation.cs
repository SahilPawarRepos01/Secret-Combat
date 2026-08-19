using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [Header("Player Animation")]
    private Animator playerAnim;

    private void Awake()
    {
        playerAnim = GetComponentInChildren<Animator>();
    }

    // Player Idle
    public void Idle()
    {
        if (playerAnim != null)
        {
            playerAnim.SetBool("isSwordRunning", false);
            playerAnim.SetBool("isJumping", false);
            playerAnim.SetBool("isRunning", false);
        }
    }

    // Idle with Sword
    public void IdleSword()
    {
        if (playerAnim != null)
        {
            playerAnim.SetBool("isRunning", false);
            playerAnim.SetBool("isSwordJumping", false);
            playerAnim.SetBool("isSwordRunning", false);
        }
    }

    // Player Run without Sword
    public void Run()
    {
        if (playerAnim != null )
        {
            //playerAnim.SetBool("isJumping", false);
            playerAnim.SetBool("isSwordRunning", false);
            playerAnim.SetBool("isRunning", true);
        }
    }
    
    // Run with Sword
    public void RunSword()
    {
        if (playerAnim != null )
        {
            //playerAnim.SetBool("isJumping", false);
            playerAnim.SetBool("isRunning", false);
            playerAnim.SetBool("isSwordRunning", true);
        }
    }

    public void Jump()
    {
        if (playerAnim != null)
        {
            playerAnim.SetBool("isJumping", true);
        }
    }
    
    // Jumping with Sword
    public void JumpSword()
    {
        if (playerAnim != null)
        {
            playerAnim.SetBool("isSwordJumping", true);
        }
    }

    // Striking with Sword - Attack 1
    public void SwordStrike()
    {
        if (playerAnim != null)
        {
            playerAnim.SetBool("isSwordStriking", true);
        }
    }

    // Player Dead
    public void Dead()
    {
        if (playerAnim != null)
        {
            playerAnim.Play("Die");
        }
    }
}
