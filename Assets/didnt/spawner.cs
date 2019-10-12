using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour {

    public GameObject enemy;
    public float timer = 0f;
    int waveNum;
    public GameObject wave1Wall;
    public GameObject wave2Wall;
    public GameObject wave3Wall;


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		timer += Time.deltaTime;


	}


}
