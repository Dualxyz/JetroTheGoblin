using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractingWith : MonoBehaviour
{
    public GameObject player;
    public GameObject item;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        Vector3 bar = item.transform.position;
        
        print(bar);
        //print(distance);
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, item.transform.position);
        if (distance < 2 && Input.GetKeyDown(KeyCode.Z)){
            print("I have interacted with an object");
        }
    }
}
