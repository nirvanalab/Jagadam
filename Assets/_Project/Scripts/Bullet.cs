using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnBecameInvisible()
    {
        //destroy object when it becomes  invisible
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //destroy object when it collides
        Destroy(gameObject);
    }
}
