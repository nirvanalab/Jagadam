using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    private static Level singleton;

    public EnemySpawning[] spawns;

    public int totalEnemies;
    private int enemiesSpawned;
    private int enemiesDestroyed;

    private bool isLevelOver = false;

	// Use this for initialization
	void Start () {
        singleton = this;
         SpawnEnemies();
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    private void SpawnEnemies()
    {
        Debug.Log("Spawn Enemies Called");

        if (enemiesSpawned >= totalEnemies)
        {
            return;
            //dont't spawn enemies
        }
        foreach (EnemySpawning spawn in spawns)
        {
            spawn.SpawnEnemy();
            enemiesSpawned++;
        }
        StartCoroutine("SpawnMoreEnemies");

    }

    public static void EnemyDestroyed()
    {
        Debug.Log("Enemy Destroyed");
        singleton.enemiesDestroyed++;
        if ( singleton.enemiesDestroyed >= singleton.totalEnemies)
        {
            GameOver(true);
        }
    }

    public static void GameOver(bool didWin)
    {
        singleton.isLevelOver = true;
        if (didWin)
        {
            //congrats 
        }
        else
        {
            //sorry you got destryoned
        }

        //restart options

    }
    private IEnumerator SpawnMoreEnemies()
    {
        while (!isLevelOver)
        {
            yield return new WaitForSeconds(10.0f);
            SpawnEnemies();
        }
    }
}
