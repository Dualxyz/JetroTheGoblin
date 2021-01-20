using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	//VARIABLES
	[SerializeField] private float moveSpeed;
	[SerializeField] private float walkSpeed;
	[SerializeField] private float runSpeed;
	
	private Vector3 moveDirection;
	private Vector3 velocity;
	
	[SerializeField] private bool isGrounded;
	[SerializeField] private float groundCheckDistance;
	[SerializeField] private LayerMask groundMask;
	[SerializeField] public float gravity;
	public bool PlayerGravity = false;
	
	[SerializeField] private float jumpHeight;
	
	//REFERENCES
	private CharacterController controller;
	private Animator anim;
	
	private void Start()
	{
		controller = GetComponent<CharacterController>();
		anim = GetComponentInChildren<Animator>();
	}
	
	private void Update()
	{
		Move();
		
		if(Input.GetKeyDown(KeyCode.Mouse0))
		{
			StartCoroutine(Attack());
		}

		if (Input.GetKeyDown(KeyCode.G)){
            SetGravity();
        }
		
	}

	 public void SetGravity(){
        if(PlayerGravity == false){
        	PlayerGravity = true;
           	GravityBoost();
        } else {
           PlayerGravity = false;
           resetGravityBoost();
        }
    }

	public void GravityBoost(){
		gravity = -20000f;
		print("gravity set to: "+ gravity);
	}

	public void resetGravityBoost(){
		gravity = -9.81f;
		print("gravity reset to: "+ gravity);
	}
	
	private void Move()
	{
		//isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);
		isGrounded = true;
		
		if(isGrounded && velocity.y < 0)
		{
			velocity.y = -2f;
		}
		
		float moveZ = Input.GetAxis("Vertical");
		
		moveDirection = new Vector3(0, 0, moveZ);
		moveDirection = transform.TransformDirection(moveDirection);
		
		if(isGrounded)
		{
			if(moveDirection != Vector3.zero && !Input.GetKey(KeyCode.LeftShift))
			{
				Walk();
			}
			else if(moveDirection != Vector3.zero && Input.GetKey(KeyCode.LeftShift))
			{
				Run();
			}
			else if(moveDirection == Vector3.zero)
			{
				Idle();
			}
			
			moveDirection *= moveSpeed;
			
			if(Input.GetKeyDown(KeyCode.Space))
			{
				Jump();
			}
		}
		
		controller.Move(moveDirection * Time.deltaTime);
		
		velocity.y += gravity * Time.deltaTime;
		controller.Move(velocity * Time.deltaTime);
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
	
	private IEnumerator Attack()
	{
		anim.SetLayerWeight(anim.GetLayerIndex("Attack Layer"), 1);
		anim.SetTrigger("Attack");
		
		yield return new WaitForSeconds(0.9f);
		anim.SetLayerWeight(anim.GetLayerIndex("Attack Layer"), 0);
	}
}
