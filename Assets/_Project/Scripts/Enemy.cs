using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {

    [SerializeField]
    public string enemyType;

    [SerializeField]
    public GameObject enemyWeapon;

    public int health;
    public int range;
    public float fireRate = 2;

    public Transform fireSpot;
    UnityEngine.AI.NavMeshAgent agent;
    public Animator robot;

    private bool isDead;
    public GameObject player;
    private float lastFiredTime;

    [SerializeField]
    private AudioClip deathSound;
    [SerializeField]
    private AudioClip weakHitSound;
    [SerializeField]
    private AudioClip fireSound;

    public Text healthText;
    public int originalHealth;

	// Use this for initialization
	void Start () {
        isDead = false;
        originalHealth = health;
        UpdateHealthText();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
        {
            if (go.tag == "Player")
            {
                player = go;
                break;
            }
        }
        //player = GameObject.Find("OVRCameraRig");
        //Debug.Log(player);
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
        GameObject weapon = Instantiate(enemyWeapon);
        weapon.transform.position = fireSpot.transform.position;
        weapon.transform.rotation = fireSpot.transform.rotation;
        GetComponent<AudioSource>().PlayOneShot(fireSound);
      // robot.Play("Fire");
      //  Debug.Log("Fire");
    }


    public void TakeHit(int amount)
    {
        health -= amount;
        Debug.Log("Enemy Health = " + health);
        if (health <= 0)
        {
            //destroy enemy
            isDead = true;
            //robot.Play("Die");
            Destroy(gameObject);
            //StartCoroutine("DestroyEnemy");
            GetComponent<AudioSource>().PlayOneShot(deathSound);
        }
        else
        {
            UpdateHealthText();
            GetComponent<AudioSource>().PlayOneShot(weakHitSound);
        }

    }

    IEnumerator DestroyEnemy()
    {
        yield return new WaitForSeconds(2);
        Destroy(gameObject);
    }

    private void UpdateHealthText()
    {
        int percentHealthRemaining = health * 100 / originalHealth;
        healthText.text = "Health: " + percentHealthRemaining + "%";
    }
}
