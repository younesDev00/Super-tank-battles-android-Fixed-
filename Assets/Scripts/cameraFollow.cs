using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollow : MonoBehaviour
{

    public float dampTime = 0.15f;//delay time
    public Vector3 velocity = Vector3.zero;
    public Transform target;

    private Camera camMain;// setting a camera component
    
        
    // Use this for initialization
	void Start ()
    {
        camMain = GetComponent<Camera>();// getting camera component from camera object in scene

	}
	
	// FixedUpdate could be used which is called once per frame for a limit of 60 frams for consistancy,
	void Update ()
    {
        
		if(target)// if statment used to check player movement
        {
            
            Vector3 point = camMain.WorldToViewportPoint(target.position);// tells the camera what object to follow
            Vector3 delta = target.position - camMain.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));// tells the camera to make the target the center of view and gets vector3 position 
            Vector3 destination = transform.position + delta;// calculates distance/position of target
            transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);//moves the camera 

        }
	}
}
