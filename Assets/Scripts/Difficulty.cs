using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difficulty : MonoBehaviour
{
    public static bool easy = false;
    public static bool medium = false;
    public static bool hard = false;
    public static bool easyGate = false;
    public static bool mediumGate = false;
    public static bool hardGate = false;

    // Use this for initialization
    void Start()
    {
        //easy = false;
        //medium = false;
        //hard = false;
        // easyGate = false;
        // mediumGate = false;
        //hardGate = false;
    }

    // Update is called once per frame
    void Update()
    {

    }



    public void SetEasy()
    {
        enemyAI.enemyshootdelay = 9;
        //player scriptplayer = gameObject.GetComponent(typeof(player)) as player;//used to get health component//used before makeing player health static
        Player.playerHealth = 200;
        //Debug.Log("added 100");
        easyGate = true;
        easy = true;
        Debug.Log(Player.playerHealth);

    }

    public void SetMeduim()
    {
        enemyAI.enemyshootdelay = 6;
        //player scriptplayer = gameObject.GetComponent(typeof(player)) as player;//used to get health component//used before makeing player health static
        Player.playerHealth = 150;
        //Debug.Log("added 50");
        medium = true;
        mediumGate = true;
    }

    public void SetHard()
    {
        enemyAI.enemyshootdelay = 3;
        hard = true;
        hardGate = true;
    }

    public void ResumeGame()
    {
        Score.playerscore = 0;
        if (easy == true)
        {
            //player.playerHealth = 200;
            //enemyAI.enemyshootdelay = 9;
            SetEasy();
            // easy = false;
        }
        else if (medium == true)
        {
            // player.playerHealth = 150;
            // enemyAI.enemyshootdelay = 6;
            SetMeduim();
            // medium = false;
        }
        else if (hard == true)
        {
              Player.playerHealth = 100;
             enemyAI.enemyshootdelay = 3;
            // hard = false;
            SetHard();
        }
        else
        {
            Player.playerHealth = 100;
            enemyAI.enemyshootdelay = 3;
            SetHard();//defult to hard
        }
    }

    public void NewGame()
    {
        //PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("CurrentMoney", 0);
        PlayerPrefs.SetInt("Highscore", 0);
        Score.playerscore = 0;
        if (easy == true)
        {
            Player.playerHealth = 200;
            enemyAI.enemyshootdelay = 9;
            //SetEasy();
            easy = false;
        }
        else if (medium == true)
        {
            Player.playerHealth = 150;
            enemyAI.enemyshootdelay = 6;
            //SetMeduim();
            medium = false;
        }
        else if (hard == true)
        {
            Player.playerHealth = 100;
            enemyAI.enemyshootdelay = 3;
            hard = false;
            //SetHard();
        }
        else
        {
            Player.playerHealth = 100;
            enemyAI.enemyshootdelay = 3;
            //SetHard();//defult to hard
        }
    }

    public void resetHighscore()
    {
        PlayerPrefs.DeleteAll();
    }


}
