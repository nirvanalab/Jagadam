using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    private static Level singleton;

    public EnemySpawning[] spawns;

    public int enemiesLeft;

	// Use this for initialization
	void Start () {
        singleton = this;
        spawnEnemies();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void spawnEnemies()
    {
        foreach(EnemySpawning spawn in spawns)
        {
            spawn.SpawnEnemy();
            enemiesLeft++;
        }
    }
}
