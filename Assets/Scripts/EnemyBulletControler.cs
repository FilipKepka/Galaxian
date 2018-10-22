using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletControler : MonoBehaviour {

    private Transform bullet;
    public float speed;
	// Use this for initialization
	void Start () {
        bullet = GetComponent<Transform>();
	}

    private void FixedUpdate()
    {
        bullet.position += Vector3.up * -speed;

        if(bullet.position.y <= -10)
        {
            Destroy(bullet.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            GameOver.isPlayerDead = true;
        }
        else if (collision.tag == "Base")
        {
            GameObject playerBase = collision.gameObject;
            BaseHealth baseHealth = playerBase.GetComponent<BaseHealth>();
            baseHealth.health -= 1;
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
