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
        GameObject enemy = Instantiate(enemies[Random.Range(0, enemies.Length)]);
        enemy.transform.position = transform.position;

    }
}
