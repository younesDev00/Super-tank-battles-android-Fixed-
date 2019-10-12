using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{

    float timer;
    public int velocity;
    public float angle;
    public GameObject explosion_0;
    GameObject[] areaObjects;
    public int damageRadius;
    public Score scriptScore;
    //public int playerscore =10;

    void Start()
    {
        // scriptScore = FindObjectOfType<Score>();
    }

    void Update()
    {
        this.transform.position += new Vector3(Mathf.Cos(angle) * velocity, Mathf.Sin(angle) * velocity, 0);//calculates direction and speed for object missile based on the position of the header of the tank
        timer += Time.deltaTime;//timer to auto destroy missile after certain amount of time
        if (timer >= 1f)
        {
            Instantiate(explosion_0, transform.position, Quaternion.identity);
            GetObjects();
            Destroy(gameObject);
        }
    }


    void OnCollisionEnter2D(Collision2D collision)// destroy
    {
        if (collision.gameObject.name == "PlayerTank")
        {
            //player scriptplayer = collision.gameObject.GetComponent(typeof(player)) as player;//used before makeing player health static
            Player.playerHealth -= 15;
        }

        if (collision.gameObject.name == "Enemy(Clone)" || collision.gameObject.name == "Enemy")
        {
            if (this.gameObject.name != "enemymissile(Clone)")
            {
                enemyAI scriptenemyai = collision.gameObject.GetComponent(typeof(enemyAI)) as enemyAI;//grabs enemy health
                scriptenemyai.enemyHealth -= 100;//enemy health is not static so has to be grabbed
                Score.playerscore += 10;
                // scriptScore.AddScore(playerscore);
                //Debug.Log("bullet colliding");
                Instantiate(explosion_0, transform.position, Quaternion.identity);
                GetObjects();//RUNS function
                Destroy(gameObject);
            }
        }
        Instantiate(explosion_0, transform.position, Quaternion.identity);
        Destroy(gameObject);

    }//area damage on wards

    void GetObjects()//to get all the enimies and players in area 
    {
        areaObjects = null;//initilises aray to zeero
        if (this.gameObject.name == "playermissile(Clone)")//stops frindly fire from occuring
        {
            areaObjects = GameObject.FindGameObjectsWithTag("Enemy");
            if (areaObjects != null)//if enemies are in radius
                AreaDamageEnemy();
        }
        if (this.gameObject.name == "enemymissile(Clone)")//checks collosion
        {
            areaObjects = GameObject.FindGameObjectsWithTag("Player");
            if (areaObjects != null)//if enemies are in radius
                AreaDamagePlayer();
        }
    }

    void AreaDamageEnemy()//checks if any enemy in array is in raduis
    {
        foreach (var enemy in areaObjects)
        {
            if (enemy.transform.position.x < transform.position.x + damageRadius && enemy.transform.position.x > transform.position.x - damageRadius
                && enemy.transform.position.y < transform.position.y + damageRadius && enemy.transform.position.y > transform.position.y - damageRadius)//simply calculates distance of each enemy from rocket
            {
                enemyAI enemyScript = enemy.gameObject.GetComponent(typeof(enemyAI)) as enemyAI;//gets enemy script
                enemyScript.enemyHealth -= 100;//does area damage of 100
                Score.playerscore += 10;//adds a score of 10
                // scriptScore.AddScore(playerscore);
            }
        }
    }

    void AreaDamagePlayer()
    {
        foreach (var enemy in areaObjects)//checks if any player in array is in raduis
        {
            if (enemy.transform.position.x < transform.position.x + damageRadius && enemy.transform.position.x > transform.position.x - damageRadius
                && enemy.transform.position.y < transform.position.y + damageRadius && enemy.transform.position.y > transform.position.y - damageRadius)//calculates distance of player from enemy rocket
            {
                //player scriptplayer = enemy.gameObject.GetComponent(typeof(player)) as player; //used before makeing player health static
                Player.playerHealth -= 15;//does - 15 player area damage
            }
        }
    }


}

