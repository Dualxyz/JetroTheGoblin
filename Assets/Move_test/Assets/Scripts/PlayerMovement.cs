using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //VARIABLES
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float runSpeed;

    public Vector3 moveDirection;
    private Vector3 velocity;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;
    public bool PlayerGravity = false;

    [SerializeField] private float jumpHeight;
    private int jumpsStack;

    //REFERENCES
    private CharacterController controller;
    private Animator anim;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
        jumpsStack = 0;
    }

    private void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(Attack());
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            SetGravity();
        }

    }

    public void SetGravity()
    {
        if (PlayerGravity == false)
        {
            PlayerGravity = true;
            GravityBoost();
        }
        else
        {
            PlayerGravity = false;
            resetGravityBoost();
        }
    }

    public void GravityBoost()
    {
        gravity = -20000f;
        print("gravity set to: " + gravity);
    }
    //commentx2
    public void resetGravityBoost()
    {
        gravity = -9.81f;
        print("gravity reset to: " + gravity);
    }

    private void Move()
    {
        //isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
        isGrounded = true;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -5f;
            jumpsStack = 0; //resets jump counter if player comback to ground
        }

        float moveZ = Input.GetAxis("Vertical");

        moveDirection = new Vector3(0, 0, moveZ);
        moveDirection = transform.TransformDirection(moveDirection);

        if (isGrounded)
        {
            if (moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
            {
                Walk();
            }
            else if (moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
            {
                Run();
            }
            else if (moveDirection == Vector3.zero)
            {
                Idle();
            }

            moveDirection *= moveSpeed;
        }

        //Jump&DoubleJump
        if (Input.GetKeyDown(KeyCode.Space) && jumpsStack < 2)
        {
            jumpsStack++;
            Jump();
        }

        Move(moveDirection);

        ApplyGravityToPlayer();
    }

    private void Idle()
    {
        anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }

    private void Walk()
    {
        moveSpeed = walkSpeed;
        anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
    }

    private void Run()
    {
        moveSpeed = runSpeed;
        anim.SetFloat("Speed", 1, 0.1f, Time.deltaTime);
    }

    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
    }

    public void Move(Vector3 movement)
    {
        this.controller.Move(movement * Time.deltaTime);
    }

    private IEnumerator Attack()
    {
        anim.SetLayerWeight(anim.GetLayerIndex("Attack Layer"), 1);
        anim.SetTrigger("Attack");

        yield return new WaitForSeconds(0.9f);
        anim.SetLayerWeight(anim.GetLayerIndex("Attack Layer"), 0);
    }

    /// <summary>
    /// Applys gravity to Player
    /// </summary>
    private void ApplyGravityToPlayer()
    {
        this.velocity.y += this.gravity * Time.deltaTime;
        Move(velocity);
    }
}
