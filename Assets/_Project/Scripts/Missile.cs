using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour {

    public float speed = 30f;
    public int damage = 10;

	// Use this for initialization
	void Start () {
        StartCoroutine("destroyMissile");	
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Missile Collision Enter");
        if(collision.gameObject.GetComponent<Player>() != null && collision.gameObject.tag == "Player")
        {
            Debug.Log("Missile-Player Collision Enter");
            collision.gameObject.GetComponent<Player>().TakeHit(damage);
        }
        Destroy(gameObject);
    }

    IEnumerator destroyMissile()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
