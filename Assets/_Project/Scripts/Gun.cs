using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {
    public float fireRate;
    protected float lastFireTime;

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
        GetComponentInChildren<Animator>().Play("Fire");
        Debug.Log("Fire");
    }
}
