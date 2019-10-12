using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float timer;
    public float timeToSpawn = 10f;
    private System.Random rnd;

    public static int minNum = 1;//for difficulty
    public static int maxNum = 5;

    public float spawnRadius;

    public static int spawnArea;

    private Vector2 spawnPos;

    public Vector2 area1Pos;
    public Vector2 area2Pos;
    public Vector2 area3Pos;


    // Use this for initialization
    void Start()
    {
        rnd = new System.Random();
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.ispaused == true)
        {
            return;
        }

        timer += Time.deltaTime;

        if (timer >= timeToSpawn)
        {
            int rndNum = rnd.Next(minNum, maxNum);//creates a random number between the desired min and max values e.g. for easy levels 4

            for (int x = 0; x < rndNum; x++)// runs the program e.g. 4 times
            {
                SpawnEnemy();
            }
            timer = 0;//difficulty
        }
    }

    void SpawnEnemy()
    {
        if (spawnArea == 1)
        {
            this.transform.position = area1Pos;//sets current position to area 1 position which is public variable
        }

        else if (spawnArea == 2)
        {
            this.transform.position = area2Pos;//sets current position to area 1 position which is public variable
        }

        else if (spawnArea == 3)
        {
            this.transform.position = area3Pos;//sets current position to area 1 position which is public variable
        }


        float rndRadiusX = rnd.Next(0, (int)spawnRadius);// used for a random spawn radius of x values to spawn enemies around
        float rndRadiusY = rnd.Next(0, (int)spawnRadius);// used for a random spawn radius of y values to spawn enemies around
        Instantiate(enemyPrefab, new Vector3(transform.position.x + rndRadiusX, transform.position.y + rndRadiusY, 0), Quaternion.identity);//instantiates enemy prefab



    }
}
