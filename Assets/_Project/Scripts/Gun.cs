using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour {
    public float fireRate;
    protected float lastFireTime;
    public GameObject bulletPrefab;
    public Transform bulletLaunchTransform;
    public AudioClip liveFire;
    public AudioClip dryFire;
    public AmmoManager ammoManager;

    public Text ammoText;
    int lastSetFrame = 0;
    // Use this for initialization
    void Start()
    {
        lastFireTime = Time.time - 10;
        UpdateAmmoText();
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
        lastSetFrame++;
        if(lastSetFrame >= 30)
        {
            lastSetFrame = 0;
            UpdateAmmoText();
        }
	}

    private void UpdateAmmoText()
    {
        int ammoRemaining = ammoManager.GetAmmo(tag);
        ammoText.text = "Ammmo: " + ammoRemaining;
    }

    protected void Fire()
    {
       if( ammoManager.HasAmmo(tag)) {
            fireBullet();
            //play sound
            GetComponent<AudioSource>().PlayOneShot(liveFire);
            ammoManager.ConsumeAmmo(tag);
            UpdateAmmoText();
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
