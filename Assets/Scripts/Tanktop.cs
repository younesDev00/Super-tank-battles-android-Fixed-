using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tanktop : MonoBehaviour
{

    public float speed;
    public Vector3 direction;
    public static float angle;// angle variable has to be set as static to be viwed on diffrent scripts
    public AudioSource shoot;

    public GameObject missile;
    public GameObject reference;

    public float shootTimer = 0f;

    bool getDirection;



    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update ()
    {

        direction = new Vector3(Mathf.Cos(angle) * speed, Mathf.Sin(angle) * speed, 0);// finds direction which gets multiplied by speed for consistancy over diffrent fram rates, has to be vector 3 due to having unity 3d option enabled 
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Rad2Deg * angle + 90);// gets vector3 direction and rotates the object towards the desired location
        //if statment to check for any input requring changes in position on horizental axis
        if (Input.GetKey(KeyCode.A))
        {
            angle += 0.045f;//0.045f is speed
        }
        if (Input.GetKey(KeyCode.S))
        {
            angle -= 0.045f;
        }
        if (Input.GetKeyDown(KeyCode.Space) || MoveTouch.shootmissile && shootTimer >=0.9f)//linked to the shoots script
        {
            var tempMissile = Instantiate(missile, reference.transform);//varriable to ease use of missile creation, clones missile and sets it to a variable 
            Rocket scriptMissile = tempMissile.GetComponent(typeof (Rocket)) as Rocket;//gets script from the missile and places it in a variable to be controlled by individual bases
            scriptMissile.angle = angle;//sets the angle of the missile variable
            tempMissile.transform.parent = null;//keeps missile from following parent position
            shootTimer = 0f;//defult value
            shoot.Play();//audio play
        }

            shootTimer += Time.deltaTime;
        
    }

    public void ShootPhone()
    {
        var tempMissile = Instantiate(missile, reference.transform);//varriable to ease use of missile creation, clones missile and sets it to a variable 
        Rocket scriptMissile = tempMissile.GetComponent(typeof(Rocket)) as Rocket;//gets script from the missile and places it in a variable to be controlled by individual bases
        scriptMissile.angle = angle;//sets the angle of the missile variable
        tempMissile.transform.parent = null;//keeps missile from following parent position
        shootTimer = 0f;//defult value
        shoot.Play();//audio play
    }
}