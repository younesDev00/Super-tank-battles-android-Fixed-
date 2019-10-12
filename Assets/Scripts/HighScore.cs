using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HighScore : MonoBehaviour
{
    public static string[,] highscores = new string[7,2];//ses up a 2d array called highscores
    public Text[,] textBoxes = new Text[7,2]; 
    public Text name1;
    public Text name2;
    public Text name3;
    public Text name4;
    public Text name5;
    public Text name6;
    public Text name7;
    public Text score1;
    public Text score2;
    public Text score3;
    public Text score4;
    public Text score5;
    public Text score6;
    public Text score7;


    public int namesListed;

    //increase score by useing playerscore += 10

	// Use this for initialization
	void Start ()
    {
        //InitArray();//initilising array
        //enters dummy values into array
        namesListed = PlayerPrefs.GetInt("NamesListed");
        textBoxes[0, 0] = name1;
        textBoxes[0, 1] = score1;

        textBoxes[1, 0] = name2;
        textBoxes[1, 1] = score2;

        textBoxes[2, 0] = name3;
        textBoxes[2, 1] = score3;

        textBoxes[3, 0] = name4;
        textBoxes[3, 1] = score4;

        textBoxes[4, 0] = name5;
        textBoxes[4, 1] = score5;

        textBoxes[5, 0] = name6;
        textBoxes[5, 1] = score6;

        textBoxes[6, 0] = name7;
        textBoxes[6, 1] = score7;

        //Load high scores from playerprefs
        for (int x = 0; x < highscores.GetLength(0); x++)
        {
            highscores[x, 0] = PlayerPrefs.GetString("Name" + x);
            highscores[x, 1] = PlayerPrefs.GetInt("Score" + x).ToString();
        }

        string[] nameArray = new string[7];
        int[] scoreArray = new int[7];

        //Splits names and scores into the two arrays
        for (int x = 0; x < highscores.GetLength(0); x++)
        {
            nameArray[x] = highscores[x, 0];
            scoreArray[x] = Convert.ToInt32(highscores[x, 1]);
        }
        //sorts the two arrays
        Array.Sort(scoreArray, nameArray);
        Array.Reverse(nameArray);
        Array.Reverse(scoreArray);
        //puts the two sorted arrays back into the highscores array
        for (int x = 0; x < highscores.GetLength(0); x++)
        {
            highscores[x, 0] = nameArray[x];
            highscores[x, 1] = scoreArray[x].ToString();
        }

        //Set the highscores and names to the text boxes
        for (int x = 0; x < highscores.GetLength(0); x++)
        {
            for (int y = 0; y < highscores.GetLength(1); y++)
            {
                textBoxes[x, y].text = highscores[x, y].ToString();
            }
        }
    }

    // Update is called once per frame
    void Update ()
    {
        
        PlayerPrefs.SetInt("NamesListed", namesListed);
        
    }

}