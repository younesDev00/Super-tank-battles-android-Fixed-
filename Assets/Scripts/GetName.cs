using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetName : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void getname(string Username)
    {
        Debug.Log(Player.name);
        Player.name = Username;
        Debug.Log("you have selected the name" + Username);
        Debug.Log(Player.name);
    }
}
