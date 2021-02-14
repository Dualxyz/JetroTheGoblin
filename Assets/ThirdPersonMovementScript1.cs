using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovementScript1 : MonoBehaviour
{

    //VARIABLES
    [SerializeField] private float moveSpeed;

    public Vector3 moveDirection; // keep track of movement while in Ground
    private Vector3 velocity; // keep track of movement while jumping

    [SerializeField] private bool isGrounded; // keep track if player is in Ground
    [SerializeField] private float groundCheckDistance; //??
    [SerializeField] private LayerMask groundMask; //??
    [SerializeField] private float gravity; // value of gravity

    [SerializeField] private float jumpHeight;
    private int jumpsStack;

    //REFERENCES
    private CharacterController controller;  //motor that drtives our player

    //Camera
    public Transform cam;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    private void Start()
    {
        this.controller = GetComponent<CharacterController>();
        isGrounded = true;
        jumpsStack = 0;
    }

    private void Update()
    {
        Move();
    }

    /// <summary>
    /// Manages the movement of the player
    /// </summary>
    private void Move()
    {
        GravityCheck();

        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(-direction.x, -direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * -Vector3.forward;
            moveDirection = moveDir.normalized * moveSpeed;
            Move(moveDirection);
        }

        //Jump&DoubleJump
        if (Input.GetKeyDown(KeyCode.Space) && jumpsStack < 2)
        {
            jumpsStack++;
            Jump();
        }

        ApplyGravityToPlayer();
    }

    /// <summary>
    /// Basic jumping mechanics
    /// </summary>
    private void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity); // can be replaced by other
    }

    /// <summary>
    /// Move the player position based on a Vector 
    /// </summary>
    /// <param name="movement">Vector used to place the player in another location</param>
    public void Move(Vector3 movement)
    {
        this.controller.Move(movement * Time.deltaTime);
    }

    /// <summary>
    /// Desables gravity if player if in ground
    /// </summary>
    private void GravityCheck()
    {
        this.isGrounded = isInGround(transform.position);

        //stops apply gravity if player is in Ground
        if (this.isGrounded && this.velocity.y < 0)
        {
            this.velocity.y = -2f;
            jumpsStack = 0; //resets jump counter if player comback to ground
        }
    }

    /// <summary>
    /// Checks if Object is in Ground based on its position transform.
    /// </summary>
    /// <param name="position">Transform containing position of Object</param>
    /// <returns></returns>
    private bool isInGround(Vector3 position)
    {
        return Physics.CheckSphere(position, this.groundCheckDistance, this.groundMask);
    }

    /// <summary>
    /// Applys gravity to Player
    /// </summary>
    private void ApplyGravityToPlayer()
    {
        this.velocity.y += this.gravity * Time.deltaTime;
        this.controller.Move(this.velocity * Time.deltaTime);
    }


}
