using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    public int type;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider collider)
    {
        //Debug.Log("On Trigger Enter");
        Debug.Log(collider.gameObject);
        if (collider.gameObject.tag == "PickupGrabber")
        {
            //Debug.Log("Player-Pickup Trigger Enter");
            Player player = FindObjectOfType<Player>();
            player.PickupItem(type);
            GetComponentInParent<PickupSpawn>().PickupPicked();
            Destroy(gameObject);
        }
    }

   /* private void OnCollisionEnter(Collision collider)
    {
        Debug.Log("On Collision Enter");
        Debug.Log(collider.gameObject);
        if (collider.gameObject.tag == "PickupGrabber" )
        {
            Debug.Log("Player-Pickup Collisionn Enter");
            player.PickupItem(type);
            Destroy(gameObject);
        }
    }*/
}
