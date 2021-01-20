using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;   //distance that player needs to close to be able to interact with an object
    public Transform interactionTransform;
    bool isFocus = false;
    Transform player;
    bool hasInteracted = false;
//XD
    public virtual void Interact(){//Virtual method 
        //This method is meant to be overwritten
        Debug.Log("Interacting with " + transform.name);
    }

    public void OnFocused (Transform playerTransform){
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused(){
        isFocus = false;
        player = null;
        hasInteracted = false;

    }

    void OnDrawGizmosSelected(){    //Draw graphics in the scene, shows the radius of the interactable object
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(interactionTransform.position, radius);
    }
    void Update(){
    if(isFocus && !hasInteracted){
        float distance = Vector3.Distance(player.position, interactionTransform.position);
        if (distance <= radius){
            Interact();
            hasInteracted = true;
        }
    }
}
}

