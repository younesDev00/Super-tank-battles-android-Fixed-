using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public static int playerscore;
    public Text playerscoregui;
    public Text CurrentScore;


    // Use this for initialization
    void Start()
    {
        // PlayerPrefs.SetInt("Highscore", 0);//used to reset
        playerscoregui.text = "Current High Score: " + PlayerPrefs.GetInt("Highscore").ToString();//text to display
        

    }
    // Update is called once per frame
    void Update ()
    {
        
        //playerscoregui.text = PlayerPrefs.GetInt("Highscore").ToString();

        CurrentScore.text = "Current Score: " + playerscore.ToString();
        if (playerscore > PlayerPrefs.GetInt("Highscore",0))//compares score and highscore
        {
            PlayerPrefs.SetInt("Highscore", playerscore);//updates save file with value
            playerscoregui.text = "New High Score: " + playerscore;
        }
       
    }


}
