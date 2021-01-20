using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;    //Target on which the camera is being focused on
    public Vector3 offset;      //The distance between the player and the camera
    public float zoomSpeed = 4f;
    public float minZoom = 5f;
    public float maxZoom = 15f;
    private float currentZoom = 10f;    //Default zoom
    public float pitch = 2f;

    //Camera rotate
    public float yawSpeed = 100f;
    public float yawInput = 0;

    // Start is called before the first frame update
    void Start(){
        
    }

    void Update(){
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;  //- because it's inverted q.q
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom); //Put the current zoom between the minZoom and maxZoom

        yawInput += Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;
    }

    // Update is called once per frame
    void LateUpdate(){
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);

        transform.RotateAround(target.position, Vector3.up, yawInput);
    }
}
