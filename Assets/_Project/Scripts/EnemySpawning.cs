using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawning : MonoBehaviour {

    [SerializeField]
    GameObject[] enemies;

    private int timesSpawned;
    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SpawnEnemy()
    {
        timesSpawned++;
        GameObject enemy = null;
        if(GamePref.GameTypeSelected == Constants.RobotGame)
        {
            enemy = Instantiate(enemies[Random.Range(0, enemies.Length-1)]);
        }
        else if (GamePref.GameTypeSelected == Constants.ZombieGame)
        {
            enemy = Instantiate(enemies[enemies.Length-1]);
        }
        else
        {
            enemy = Instantiate(enemies[Random.Range(0, enemies.Length)]);
        }

        enemy.transform.position = transform.position;

    }

}
