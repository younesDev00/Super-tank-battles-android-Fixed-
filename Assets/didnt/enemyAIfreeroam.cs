using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAIfreeroam : MonoBehaviour {

    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 2f;
    private float characterVelocity = 3f;
    private Vector2 movementDirection;
    public Vector2 movementPerSecond;
    public float distancetoplayer;
    public Rigidbody2D player;



    // Use this for initialization
    void Start () {
        latestDirectionChangeTime = 0f;
        calcuateNewMovementVector();


    }

    void calcuateNewMovementVector()
    {
        //create a random direction vector with the magnitude of 1, later multiply it with the velocity of the enemy
        movementDirection = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f)).normalized;
        movementPerSecond = movementDirection * characterVelocity;
        

    }

    // Update is called once per frame
    void Update () {
        distancetoplayer = Vector3.Distance(transform.position, player.position);
        //if the changeTime was reached, calculate a new movement vector
        if (Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            calcuateNewMovementVector();

        }

        if (distancetoplayer > 225)
        {
        transform.position = new Vector2(transform.position.x + (movementPerSecond.x),
        transform.position.y + (movementPerSecond.y * Time.deltaTime));

        }



    }



    
}
