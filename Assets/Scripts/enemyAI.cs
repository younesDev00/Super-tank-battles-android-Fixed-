using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class enemyAI : MonoBehaviour
{
    public Vector3 directionEne;
    public float distanceToPlayer;
    public float angle;
    public GameObject rocket;
    public GameObject reference;

    public float timer;//set to public for testing
    public int enemyHealth;
    public AudioSource Enemyshoot;

    //used for difficulty change
    public static int enemyshootdelay = 3;




    //public Text playerScoreGui;



    // Use this for initialization
    void Start ()
    {
        enemyHealth = 100;

    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Player.ispaused == true)
        {
            return;
        }

        //Calculate distance
        distanceToPlayer = Vector3.Distance(transform.position, Player.pos); //calculates how far the player is from current object(enemy) could be written as Mathf.Abs((transform.position.x - player.transform.position.x) + (transform.position.y - player.transform.position.y));
        directionEne = Player.pos - transform.position;//finds vector3 direction to player
        directionEne.Normalize();//shortens enemies view of direction, used to control speed 
        
        angle = Mathf.Atan2(directionEne.y, directionEne.x) * Mathf.Rad2Deg;//gets the angle from current object to player needs to be changed to degrees
        if (distanceToPlayer <= 450)// set range here, if statment to check if player is in range,
        {
            timer += Time.deltaTime;
            if (timer >= enemyshootdelay)
            {
                enemyshooting();
                Enemyshoot.Play();
            }
            transform.eulerAngles = new Vector3(0, 0, angle);
            transform.position += directionEne * 2.5f;//sets chase speed
        }

        if (distanceToPlayer > 450)//makes enemy seem like free roaming
        {
            transform.eulerAngles = new Vector3(0, 0, angle);
            transform.position += directionEne * 1.5f;//sets follow speed

        }

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);

        }

    }

    void enemyshooting()
    {
        //Debug.Log("enemy is shooting");
        var tempMissile = Instantiate(rocket, reference.transform);//varriable to ease use of missile creation, clones missile and sets it to a variable 
        Rocket scriptMissile = tempMissile.GetComponent(typeof(Rocket)) as Rocket;//gets script from the missile
        scriptMissile.angle = angle * Mathf.Deg2Rad;//sets the angle of the missile variable
        tempMissile.transform.parent = null;//keeps missile from following parent position
        timer = 0;
    }



}
