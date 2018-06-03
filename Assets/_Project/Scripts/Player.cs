using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public int health = 100;
    private AmmoManager ammo;

    public void TakeHit(int amount)
    {
        health -= amount;
        Debug.Log("Health = " + health);
        if (health <= 0)
        {
            //game over
            Debug.Log("Game Over");
        }
    }

	// Use this for initialization
	void Start () {
        ammo = GetComponent<AmmoManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void pickupHealth()
    {
        health += 50;
        if ( health > 250 )
        {
            health = 250;
        }
    }

    private void pickupAssaultRifleAmmo()
    {
        ammo.AddAmmo(Constants.AssaultRifle, 50);
    }

    private void pickupShortgunAmmo()
    {
        ammo.AddAmmo(Constants.AssaultRifle, 20);
    }

    private void pickupPistolAmmo()
    {
        ammo.AddAmmo(Constants.AssaultRifle, 20);
    }

    public  void PickupItem(int pickupItem)
    {
        switch(pickupItem)
        {
            case Constants.PickupAssaultRifleAmmo:
                this.pickupAssaultRifleAmmo();
                break;
            case Constants.PickupHealth:
                this.pickupHealth();
                break;
            case Constants.PickupPistolAmmo:
                this.pickupPistolAmmo();
                break;
            case Constants.PickupShotgunAmmo:
                this.pickupShortgunAmmo();
                break;
            default:
                break;
        }
    }

    public static implicit operator GameObject(Player v)
    {
        throw new NotImplementedException();
    }
}
