using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float speed = 3.0f;
    public static Vector3 direction;
    public static float angle;
    public GameObject tankTop;
    public static Vector3 pos;
    public bool areaFound;

    public static string name = "Name not set";




    public Text playerHealthGui;
    //used for difficulty change
    public static int playerHealth = 100;

    public GameObject pausemenu;
    public GameObject highscore;
    public static bool ispaused = false;
    public static bool isdead = false;
    public GameObject playerTank;

    int namesListed;
    // Use this for initialization
    void Start()
    {
        Debug.Log(name);
        // sets a defult function
        //playerHealth = 100;//used before makeing player health static
        //PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(playerHealth);
        if (Input.GetKey(KeyCode.P))
        {
            pausemenu.SetActive(true);
            ispaused = true;
        }

        if (ispaused == true)
        {
            //Debug.Log("paused");
            pausemenu.SetActive(true);
            if (Input.GetKey(KeyCode.Escape) && ispaused == true)
            {
                pausemenu.SetActive(false);
                ispaused = false;
            }
            return;
        }



        pos = transform.position;//to make enemies follow you
        direction = new Vector3(Mathf.Cos(angle) * speed, Mathf.Sin(angle) * speed, 0);
        transform.rotation = Quaternion.Euler(0f, 0f, Mathf.Rad2Deg * angle + 90);// quaternion value calculates player rotation and +90 allows the player object to be rotated without loss of forward direction
        //rb.MoveRotation(rb.rotation + 10f * Time.deltaTime);
        //if statment to check for any input requring changes in psition on horizental axis
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            angle += 0.1f;
            Tanktop.angle += 0.1f;//keeps tank header in relevant position while rotating the tank
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            angle -= 0.1f;
            Tanktop.angle -= 0.1f;//keeps tank header in relevant position while rotating the tank
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += direction;
            //Debug.Log(direction);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= direction;
        }


        if (playerHealth <= 0)
        {
            //Saves name and score to playerprefs
            namesListed = PlayerPrefs.GetInt("NamesListed");
            string nameSave = "Name" + namesListed;
            string scoreSave = "Score" + namesListed;
            PlayerPrefs.SetString(nameSave, name);
            PlayerPrefs.SetInt(scoreSave, Score.playerscore);
            namesListed++;
            PlayerPrefs.SetInt("NamesListed", namesListed);

            highscore.SetActive(true);
            isdead = true;
            ispaused = true;
            Destroy(gameObject);
            playerHealth = 0;
        }

        playerHealthGui.text = "Health:  " + playerHealth.ToString();
    }


    public void MovePosition(Vector3 position) // changes spawn position of player
    {
        this.transform.position = position;
    }

}