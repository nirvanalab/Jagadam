using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSpawn : MonoBehaviour {

    [SerializeField]
    public GameObject[] pickups;
	// Use this for initialization
	void Start () {
        SpawnPickup();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void SpawnPickup()
    {
        GameObject pickup = Instantiate(pickups[Random.Range(0,pickups.Length)]);
        pickup.transform.position = transform.position;
        pickup.transform.parent = transform;
    }

    IEnumerator RespawnPickup()
    {
        yield return new WaitForSeconds(20);
        SpawnPickup();
    }

    public void PickupPicked()
    {
        StartCoroutine("RespawnPickup");
    }

}
