using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveTouch : MonoBehaviour
{
    public bool moveleft = false;
    public bool moveright = false;
    public bool moveforward = false;
    public bool movebackward = false;
    public GameObject playerTank;
    public GameObject pausemenu;
    public bool unpause = false;
    public bool pause = false;
    public static bool shootmissile = false;


    public static float angle;// angle variable has to be set as static to be viwed on diffrent scripts
    public AudioSource shoot;
    public GameObject missile;
    public GameObject reference;
    public float shootTimer = 0f;

    // Use this for initialization
    void Start()
    {
        pause = false;

    }

    public void MoveLeftTrue()
    {
        if (Player.ispaused == false)
        {
            moveleft = true;
        }
    }

    public void MoveLeftFalse()
    {
        moveleft = false;
    }



    public void MoveRightTrue()
    {
        if (Player.ispaused == false)
        {
            moveright = true;
        }
    }

    public void MoveRightFalse()
    {
        moveright = false;
    }

    public void MoveforwardTrue()
    {
        if (Player.ispaused == false)
        {
            moveforward = true;
        }
    }

    public void MoveforwardFalse()
    {
        moveforward = false;
    }

    public void MoveBackwardTrue()
    {
        if (Player.ispaused == false)
        {
            movebackward = true;
        }
    }

    public void MoveBackwardFalse()
    {
        movebackward = false;
    }

    public void UnPauseGame()
    {
        unpause = true;
    }

    public void PauseGame()
    {
        pause = true;
    }

    public void phoneshootenter()
    {
        shootmissile = true;
    }

    public void phoneshootexit()
    {
        shootmissile = false;
    }



    // Update is called once per frame
    void Update()
    {
       
        if (unpause == true)
        {
            pausemenu.SetActive(false);
            Player.ispaused = false;
            unpause = false;

        }

        if (pause == true)
        {
            Player.ispaused = true;
            pause = false;
        }

        if (moveleft == true && Player.ispaused == false)
        {
            Player.angle += 0.1f;
            Tanktop.angle += 0.1f;//keeps tank header in relevant position while rotating the tank
        }

        if (moveright == true && Player.ispaused == false)
        {
            Player.angle -= 0.1f;
            Tanktop.angle -= 0.1f;//keeps tank header in relevant position while rotating the tank
        }

        if (moveforward == true && Player.ispaused == false)
        {
            playerTank.transform.position += Player.direction; 
            //Debug.Log(direction);
        }
        if (movebackward == true && Player.ispaused == false)
        {
            playerTank.transform.position -= Player.direction;
        }

    }
    

}
