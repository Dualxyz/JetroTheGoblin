using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;   //To enable using the NavMeshAgent

[RequireComponent(typeof(NavMeshAgent))]    //Whenever you use this component, Unity will add a NavMeshAgent
public class PlayerMotor : MonoBehaviour{

    Transform target;
    NavMeshAgent agent;
    // Start is called before the first frame update
    void Start(){
        agent = GetComponent<NavMeshAgent>();
    }

    //Support for tracking a target
    public void FollowTarget(Interactable newTarget){
        agent.stoppingDistance = newTarget.radius * .8f;    //Stop at a specific distance from the interactable object
        agent.updateRotation = false;
        target = newTarget.transform;
    }

    public void StopFollowingTarget(){
        agent.stoppingDistance = 0;                         //reset the stopping distance so that we don't go further and further
        agent.updateRotation = true;
        target = null; 
    }

    // Update is called once per frame
    public void MoveToPoint(Vector3 point) {
        agent.SetDestination(point);
    }

    void FaceTarget(){
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0f, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5);
    }

    void Update(){
        if (target != null){
            agent.SetDestination(target.position);
            FaceTarget();
        }
    }
}
