using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovementScript1 : MonoBehaviour
{

    //VARIABLES
    [SerializeField] private float moveSpeed;

    private Vector3 moveDirection; // keep track of movement while in Ground
    private Vector3 velocity; // keep track of movement while jumping

    [SerializeField] private bool isGrounded; // keep track if player is in Ground
    [SerializeField] private float groundCheckDistance; //??
    [SerializeField] private LayerMask groundMask; //??
    [SerializeField] private float gravity; // value of gravity

    //REFERENCES
    private CharacterController controller;  //motor that drtives our player

    //Camera
    public Transform cam;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    private void Start()
    {
        this.controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();

    }

    // Update is called once per frame
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
            controller.Move(moveDir.normalized * moveSpeed * Time.deltaTime);

            ApplyGravityToPlayer();
        }

    }

    private void GravityCheck()
    {
        this.isGrounded = isInGround(transform.position);

        //stops apply gravity if player is in Ground
        if (this.isGrounded && this.velocity.y < 0)
        {
            this.velocity.y = -2f;
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
