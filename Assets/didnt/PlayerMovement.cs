using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{/* 

   //public float playerMoveSpeed = 10.0f; // sets the move speed as public to be edited through unity UI
   Rigidbody2D gameObject;
   float speed = 0.5F;



    // Use this for initialization
    void Start()
    {
        gameObject = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame

    void Update()
    {
        Vector3 oldPos = this.transform.position;
        float newX = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float newY = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        gameObject.MovePosition(new Vector3(oldPos.x + newX, oldPos.y + newY, oldPos.z));
    }


    old code
    //if statment to check for any input requring changes in psition on horizental axis
    if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < 0.5f )
    {
        //transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * playerMoveSpeed * Time.deltaTime, 0f, 0f));
        // * Time.delta time helps keep player movement consistant on diffrent frame rates, f = float,  0f 0f is y and z

    }

    if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < 0.5f)
    {
        //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * playerMoveSpeed * Time.deltaTime, 0f));
        // * Time.delta time helps keep player movement consistant on diffrent frame rates, f = float, 0f 0f is x and z 
    }
    */
    //playerMoveAnim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
    //playerMoveAnim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
}