using UnityEditor.Tilemaps;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header ("Player Reference")]
    PlayerAnimation playerAnimation;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [Header ("Player Movement")]
    [SerializeField] float movSpeed = 5f;
    [SerializeField] float gravity = 20f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float verticalVelocity = 0f;
    private bool isGrounded = true;
    private bool isJumping = false;
    private bool isRunning = false;
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
        if(xAxis == 0)
        {
            isRunning = false;
        }
        // bool isMoving = xAxis != 0f;

        if (Input.GetKey(KeyCode.A))
        {
            isRunning = true;
            Debug.Log("Left");
            spriteRenderer.flipX = true;
            //playerAnimation.Running();
            xAxis = -1f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            isRunning = true;
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

        if (Input.GetKeyDown(KeyCode.W) && isGrounded || Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            verticalVelocity = jumpForce;
            isGrounded = false;
            isJumping = true;
        }
        // Gravity
        verticalVelocity -= gravity * Time.deltaTime;
        // Vertical Movement
        Vector3 verticalMovement = new Vector3(0, verticalVelocity *  Time.deltaTime, 0);
        // Jump Movement
        transform.position += verticalMovement;
        // Checks the Y = 0 for isGrounded = true   
        if (transform.position.y <= 0f)
        {
            transform.position = new Vector3(transform.position.x,0f, transform.position.z);
            verticalVelocity = 0f;
            isGrounded = true;

            if (isRunning && xAxis==0)
            {
                playerAnimation.Idle();
            }
            else if(!isRunning && xAxis!=0)
            {
                playerAnimation.Run();
            }
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
