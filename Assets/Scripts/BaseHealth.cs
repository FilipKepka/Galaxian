using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseHealth : MonoBehaviour {


    public float health = 2;
	// Use this for initialization
	void Start () { 
	}
	
	// Update is called once per frame
	void Update () {
		if(health <= 0)
        {
            Destroy(gameObject);
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            health--;
        }
    }
}
