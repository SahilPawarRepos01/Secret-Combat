using UnityEditor.Tilemaps;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header ("Player Reference")]
    PlayerAnimation playerAnimation;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Header ("Player Movement")]
    [SerializeField] float movSpeed = 5f;
    [SerializeField] float gravity = 10f;
    [SerializeField] float jumpForce = 5f;
    private bool isGrounded = true;
    //bool isRunning = false;

    private void Start()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        //spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Movement();
        Attack();
    }

    private void Movement()
    {
        // Player Movement              <---
        float xAxis = 0f;
        // bool isMoving = xAxis != 0f;

        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Left");
            spriteRenderer.flipX = true;
            //playerAnimation.Running();
            xAxis = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Debug.Log("Right");
            spriteRenderer.flipX = false;
            xAxis = 1f;
        }

        // Player Animation            <---
        if (playerAnimation != null)
        {
            if (xAxis != 0)
            {
                playerAnimation.Run();
            }
            else
            {
                playerAnimation.Idle();
            }
        }

        Vector3 playerVector = new Vector3(xAxis * movSpeed * Time.deltaTime, 0, 0);
        transform.position += playerVector;

        // Player Jump                  <---
        Vector3 jump = Vector3.up;

        if (Input.GetKeyDown(KeyCode.W) && isGrounded == true || Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            isGrounded = false;
            
        }

        if (playerAnimation != null)
        {
            if (isGrounded == false)
            {
                playerAnimation.Jump();
            }
        }
    }

    private void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("FIREEE");
            
            
        }
    }
}
