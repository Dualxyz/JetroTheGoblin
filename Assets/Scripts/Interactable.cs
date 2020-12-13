using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;   //distance that player needs to close to be able to interact with an object
    
    void OnDrawGizmosSelected(){    //Draw graphics in the scene, shows the radius of the interactable object
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
