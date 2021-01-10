using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Always check for a component at the start QWQ
[RequireComponent(typeof(PlayerMotor))]
public class playerController : MonoBehaviour{
    // Start is called before the first frame update
    //Example for rosman

    public int FloatNumber = 0; 
    public Interactable focus;
    public LayerMask movementMask; //Which objects we want to filter
    Camera cam; //Reference to the camera 
    PlayerMotor motor;

    void SetFocus(Interactable newFocus){
        if (newFocus != focus){

            if(focus != null)
                focus.OnDefocused();

            focus = newFocus;
            motor.FollowTarget(newFocus);
        }

        focus = newFocus;   //Coordinates of the target that we want to move to
        newFocus.OnFocused(transform);
        motor.FollowTarget(newFocus);   //Moving to the target
    }

    void RemoveFocus(){
        if (focus != null)
             focus.OnDefocused();
        focus = null;   //Reset the coordinates
        motor.StopFollowingTarget();    //Stop following the target
    }
    void Start(){
        cam = Camera.main;  //Put the main camera in a variable cam at the start of the scene
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update(){
        if(Input.GetMouseButtonDown(0)){    //Check if LMB is pressed
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);    //Shoots a ray from our current mouse position
            RaycastHit hit; //Variable in which we're gonna store what we clicked on

            if (Physics.Raycast(ray, out hit, 100, movementMask)){ //Takes the 'ray' and outputs it to the variable hit, range 100, mvMask)
                Debug.Log("We hit " + hit.collider.name + " " + hit.point); 
                //move our player to what we hit
                motor.MoveToPoint(hit.point);

                //stop focusing any object
                RemoveFocus();
            }
        }

        if(Input.GetMouseButtonDown(1)){    //Check if LMB is pressed
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);    //Shoots a ray from our current mouse position
            RaycastHit hit; //Variable in which we're gonna store what we clicked on

            if (Physics.Raycast(ray, out hit, 100)){ //Takes the 'ray' and outputs it to the variable hit, range 100, mvMask)
                //Check if we interact with an interactable object
                //Set focus to it
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                if (interactable != null){
                    SetFocus(interactable);
                }
            }
        }
    }


}
