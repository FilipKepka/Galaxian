﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EnemyController : MonoBehaviour {

    private Transform enemyHolder;
    public float speed;

    public GameObject singleEnemy;
    public List<Transform> enemyList;
    public GameObject shot;
    public Text winText;
    public float fireRate = 0.997F;

	// Use this for initialization
	void Start () {
        winText.enabled = false;
        InvokeRepeating("MoveEnemy", 0.1f, 0.3f);
        enemyHolder = GetComponent<Transform>();
        enemyList.Add(Instantiate(singleEnemy.transform, new Vector3(-6, 8), new Quaternion()));
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void MoveEnemy()
    {
        enemyHolder.position += Vector3.right * speed;

        foreach (Transform enemy in enemyList)
        {
            if(enemy.position.x < - 10.5 || enemy.position.x > 10.5)
            {
                speed = -speed;
                enemyHolder.position += Vector3.down * 0.5f;
                return;
            }

            if(Random.value > fireRate)
            {
                Instantiate(shot, enemy.position, enemy.rotation);
            }

            if(enemy.position.y <= -4)
            {
                GameOver.isPlayerDead = true;
                Time.timeScale = 0;
            }
        }

        if(enemyList.Count == 1)
        {
            CancelInvoke();
            InvokeRepeating("MoveEnemy", 0.1f, 0.25f);
        }

        if(enemyList.Count == 0)
        {
            winText.enabled = true;
        }
    }
}
