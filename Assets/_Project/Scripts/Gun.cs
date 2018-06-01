using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public float fireRate;
    protected float lastFireTime;
    public GameObject bulletPrefab;
    public Transform bulletLaunchTransform;
    public AudioClip liveFire;
    public AudioClip dryFire;
    public AmmoManager ammoManager;

	// Use this for initialization
	void Start()
    {
        lastFireTime = Time.time - 10;
	}
	
    //Checks if the right trigger of the controller is pressed
    public bool IsRightTriggerPressed()
    {
        float triggerValue = OVRInput.Get(OVRInput.RawAxis1D.RIndexTrigger);
        return triggerValue > 0.2;
    }

	// Update is called once per frame
	protected virtual void Update()
    {
		
	}

    protected void Fire()
    {
       if( ammoManager.HasAmmo(tag)) {
            fireBullet();
            //play sound
            GetComponent<AudioSource>().PlayOneShot(liveFire);
            ammoManager.ConsumeAmmo(tag);
        }
       else
        {
            GetComponent<AudioSource>().PlayOneShot(dryFire);
        }

        GetComponentInChildren<Animator>().Play("Fire");
       
       // Debug.Log("Fire");
    }

    protected void fireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab) as GameObject;
        bullet.transform.position = bulletLaunchTransform.position;
        bullet.transform.rotation = bulletLaunchTransform.rotation;
        bullet.GetComponent<Rigidbody>().velocity = transform.parent.forward * 100;
        // Destroy the bullet after 2 seconds
        //Destroy(bullet, 2.0f);
    }
}
