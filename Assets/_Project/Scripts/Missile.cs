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

    IEnumerator destroyMissile()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
