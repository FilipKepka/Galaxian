using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHolder : MonoBehaviour {

    public Text winText;
    public GameObject NormalEnemy;
    public static List<Transform> enemyList = new List<Transform>();
    private Transform enemyHolder;
    private float speed = 0.05f;

	// Use this for initialization
	void Start () {      
        enemyHolder = GetComponent<Transform>();
        InitializeEnemy();
    }

    // Update is called once per frame
    void Update () {
        enemyHolder.position += Vector3.right * speed;

        foreach (Transform enemy in enemyList)
        {
            
            if (enemy.position.x < -12.5 || enemy.position.x > 12.5)
            {
                speed = -speed;
                enemyHolder.position += Vector3.down * 0.5f;
                return;
            }

            if (enemy.position.y <= -4)
            {
                GameOver.isPlayerDead = true;
                Time.timeScale = 0;
            }
        }

        if (enemyList.Count == 0)
        {
            winText.enabled = true;
        }
    }


    private void InitializeEnemy()
    {
        float enemyLimitAxis_X = 10f;
        float enemyLimitAxis_Y = 4f;
        float enemyStartingPosition_X = -8f;
        float enemyStartingPosition_Y = 10f;

        for (int y = 0; y < enemyLimitAxis_Y; y++)
        {
            for (int x = 0; x < enemyLimitAxis_X; x++)
            {
                enemyList.Add(Instantiate(NormalEnemy.transform, 
                    new Vector3(enemyStartingPosition_X, enemyStartingPosition_Y), 
                    new Quaternion()));
                enemyStartingPosition_X += 1.5f;
            }
            enemyStartingPosition_X = -8f;
            enemyStartingPosition_Y += 1.5f;
        }

        foreach (var enemy in enemyList)
        {
            enemy.transform.parent = enemyHolder.transform;
        }
    }
}
