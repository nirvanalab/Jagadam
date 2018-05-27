using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Gun {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	override protected void Update () {
        base.Update();
        //float triggerValue = OVRInput.Get(OVRInput.Axis1D.SecondaryIndexTrigger);
        if (IsRightTriggerPressed() && (Time.time - lastFireTime > fireRate))
        {
            Fire();
            lastFireTime = Time.time;
        }
	}
}
