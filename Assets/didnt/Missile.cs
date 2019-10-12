using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{

    // Use this for initialization
    GameObject reference;
    GameObject missile;
    Vector3 direction;
    public bool destroy;
    float timer;

    public Missile(GameObject reff, GameObject missile, Vector3 dir)
    {
        reference = reff;
        this.missile = missile;
        direction = dir;
        Instantiate(this.missile, reference.transform);

    }

    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer += Time.deltaTime;
        missile.transform.position += direction;
        if (timer >= 2)
        {
            destroy = true;
        }
        if (destroy)
            missile.SetActive(false);
    }
}
