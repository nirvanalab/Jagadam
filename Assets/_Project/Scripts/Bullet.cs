using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public int damage=25;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnBecameInvisible()
    {
        //destroy object when it becomes  invisible
       // Destroy(gameObject);
       // gameObject.GetComponent<Rigidbody>().useGravity = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Bullet collision");
        if (collision.gameObject.GetComponent<Enemy>() != null && collision.gameObject.tag == "Enemy")
        {
            Debug.Log("Enemy-Player Collision Enter");
            collision.gameObject.GetComponent<Enemy>().TakeHit(damage);
        }
        //destroy object when it collides
        Destroy(gameObject);
       // gameObject.GetComponent<Rigidbody>().useGravity = true;
    }
}
