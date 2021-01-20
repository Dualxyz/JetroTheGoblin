using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    private GameObject player;
    public GameObject NPCC;
    private float distance;
    // Start is called before the first frame update
    void Start()
    {
        //Vector3 bar = NPCC.transform.position;
        //item = this.gameObject;
        //print(bar);
        //print(distance);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector3.Distance(player.transform.position, NPCC.transform.position);
        if (distance < 2 && Input.GetKeyDown(KeyCode.Z)){
            print("I have interacted with an object");
        }
    }
}
