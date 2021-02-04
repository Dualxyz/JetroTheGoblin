using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovementScript1 : MonoBehaviour
{
    public CharacterController controller;  //motor that drtives our player
    public Transform targetPosition;
    public Rigidbody test;
    public Transform cam;
    public float speed = 6f;
    public float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    [SerializeField] private float gravity = -9.81f;
	public bool PlayerGravity = false;

    // Update is called once per frame
    void walk(){
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0, vertical).normalized;

        if(direction.magnitude >= 0.1f){
            float targetAngle = Mathf.Atan2(-direction.x, -direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * -Vector3.forward;
            controller.Move(moveDir.normalized*speed*Time.deltaTime);
            
            //targetPosition.position = Vector3.MoveTowards;
            //controller.Move(*Time.deltaTime*gravity);
            
        }
        //direction.y = gravity;
        //controller.Move();
    }

    void Update()
    {
        walk();

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
//commentx2
	public void resetGravityBoost(){
		gravity = -9.81f;
		print("gravity reset to: "+ gravity);
	}
    
}
