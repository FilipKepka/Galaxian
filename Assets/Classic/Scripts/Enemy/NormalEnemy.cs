using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalEnemy : MonoBehaviour {

    private float speed = 0.1f;
    private float fireRate = 0.999f;
    public Transform enemy;
    public GameObject shot;
    
	// Use this for initialization
	void Start () {
        enemy = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Random.value > fireRate)
        {
            Instantiate(shot, enemy.position, enemy.rotation);
        }
    }
}
