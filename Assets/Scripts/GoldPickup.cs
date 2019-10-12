using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldPickup : MonoBehaviour
{
    public int GoldValue;
    public MoneyManager scriptMM;


	// Use this for initialization
	void Start ()
    {
        scriptMM = FindObjectOfType<MoneyManager>();
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D other) //on collosion with other objecct
    {
        if (other.gameObject.name == "PlayerTank")// if other object is player
        {
            scriptMM.AddMoney(GoldValue);//add value of gold to players money
            Destroy(gameObject);//destroys coin
        }
    }
}
