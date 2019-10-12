using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour
{
    public GameObject GateOne;
    public GameObject GateTwo;
    public int coins;
    bool movedPlayer1 = false;//area 2
    bool movedPlayer2 = false;//area 2
    bool movedPlayer3 = false;
    Player scriptPlayer;
    public GameObject won;

    // Use this for initialization
    void Start()
    {
        GateOne.gameObject.SetActive(true);
        GateTwo.gameObject.SetActive(true);
        scriptPlayer = gameObject.GetComponent<Player>() as Player;

    }
    // Update is called once per frame
    void Update()
    {
        coins = PlayerPrefs.GetInt("CurrentMoney");//grabs value of coins from player prefs

        if (coins <= 3 && !movedPlayer1)//if player is in wave one
        {
            EnemySpawner.spawnArea = 1;//makes enemy spawner in wave one
//            scriptPlayer.MovePosition(new Vector3(-50, -50, 0));//moves player to wave one spawn position
            movedPlayer1 = true;
            if (Difficulty.easyGate == true)//used to change difficuly at each wave
            {
                EnemySpawner.minNum = 1;
                EnemySpawner.maxNum = 3;
            }
            if (Difficulty.mediumGate == true)
            {
                EnemySpawner.minNum = 2;
                EnemySpawner.maxNum = 4;
            }
            if (Difficulty.hardGate == true)
            {
                EnemySpawner.minNum = 2;
                EnemySpawner.maxNum = 5;
            }

            
        }
        if (coins >= 3 && !movedPlayer2)//used to change difficuly at each wave
        {
            EnemySpawner.spawnArea = 2;
            scriptPlayer.MovePosition(new Vector3(1550, 950, 0));//moves player to spawn position 2
            //GateOne.SetActive(false);//previously used as levels were connected
            movedPlayer2 = true;
            if (Difficulty.easyGate == true)
            {
                EnemySpawner.minNum = 3;
                EnemySpawner.maxNum = 5;
            }
            if (Difficulty.mediumGate == true)
            {
                EnemySpawner.minNum = 4;
                EnemySpawner.maxNum = 6;
            }
            if (Difficulty.hardGate == true)
            {
                EnemySpawner.minNum = 4;
                EnemySpawner.maxNum = 7;
            }
        }
        /*else
        {
            GateOne.gameObject.SetActive(true);//previously used as levels were connected
        }*/

        if (coins >= 6 && !movedPlayer3)
        {
            EnemySpawner.spawnArea = 3;
            scriptPlayer.MovePosition(new Vector3(550, 965, 0));
            //GateTwo.SetActive(false);//previously used as levels were connected
            movedPlayer3 = true;
            if (Difficulty.easyGate == true)
            {
                EnemySpawner.minNum = 9;
                EnemySpawner.maxNum = 12;
            }
            if (Difficulty.mediumGate == true)
            {
                EnemySpawner.minNum = 11;
                EnemySpawner.maxNum = 14;
            }
            if (Difficulty.hardGate == true)
            {
                EnemySpawner.minNum = 13;
                EnemySpawner.maxNum = 16;
            }
        }
        /*else
        {
            GateTwo.gameObject.SetActive(true);//previously used as levels were connected
        }*/

        if (coins >= 9)
        {
            won.SetActive(true);
            Player.ispaused = true;
        }

    }
}
