using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int health = 100;

    public void TakeHit(int amount)
    {
        health -= amount;
        Debug.Log("Health = " + health);
        if (health <= 0)
        {
            //game over
            Debug.Log("Game Over");
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
