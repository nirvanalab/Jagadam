using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]
    public string enemyType;

    public int health;
    public int range;
    public float fireRate = 2;

    public Transform fireSpot;
    UnityEngine.AI.NavMeshAgent agent;

    private bool isDead;
    public GameObject player;
    private float lastFiredTime;

	// Use this for initialization
	void Start () {
        isDead = false;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        //player = GameObject.FindGameObjectWithTag("Payer").transform;
	}
	
	// Update is called once per frame
	void Update () {
		if(isDead)
        {
            return;
        }

        transform.LookAt(player.transform);
        agent.SetDestination(player.transform.position);

        float distanceBetweenEnemyAndPlayer = Vector3.Distance(transform.position, player.transform.position);
        if(distanceBetweenEnemyAndPlayer < range && ((Time.time - lastFiredTime)>fireRate))
        {
            lastFiredTime = Time.time;
            Fire();
        }
	}

    private void Fire()
    {
        Debug.Log("Fire");
    }
}
