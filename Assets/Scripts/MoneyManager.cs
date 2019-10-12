using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyManager : MonoBehaviour
{
    public Text moneyGUI;
    public int currentGold;


    // Use this for initialization
    void Start()
    {
        

        if (PlayerPrefs.HasKey("CurrentMoney"))// checking to see if value of money already exists
        {
            currentGold = PlayerPrefs.GetInt("CurrentMoney"); //useing player prefs to store amount of money a player has
        }
        else//if  there is no value of money 
        {
            currentGold = 0;// setting value of current money to zero
            PlayerPrefs.SetInt("CurrentMoney", 0);// creating a save file with the value of money defult to zero
        }


    }

    // Update is called once per frame
    void Update()
    {
        moneyGUI.text = "Gold: " + currentGold;
    }

    public void AddMoney(int goldToAdd)//used to directly add money to save file
    {
        currentGold += goldToAdd;
        PlayerPrefs.SetInt("CurrentMoney", currentGold);//updates save file with value of current money
    }
}
