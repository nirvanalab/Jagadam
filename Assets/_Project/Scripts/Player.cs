using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour {

    public int health = 100;
    private AmmoManager ammo;

    public Text[] healthTexts;
  
    public void TakeHit(int amount)
    {
        health -= amount;
        Debug.Log("Health = " + health);
        if (health <= 0)
        {
            //game over
            health = 0;
            Level.GameOver(false);
            Debug.Log("Game Over");
        }

        UpdateHalthTexts();
    }

    public void UpdateHalthTexts()
    {
        foreach(Text healthText in healthTexts)
        {
            healthText.text = "Health: " + health;
        }
    }
	// Use this for initialization
	void Start () {
        ammo = GetComponent<AmmoManager>();
        UpdateHalthTexts();

    }
	
	// Update is called once per frame
	void Update () {
  	}

    private void pickupHealth()
    {
        health += 50;
        if ( health > 100 )
        {
            health = 100;
        }

        UpdateHalthTexts();
    }

    private void pickupAssaultRifleAmmo()
    {
        ammo.AddAmmo(Constants.AssaultRifle, 50);
    }

    private void pickupShortgunAmmo()
    {
        ammo.AddAmmo(Constants.Shotgun, 20);
    }

    private void pickupPistolAmmo()
    {
        ammo.AddAmmo(Constants.Pistol, 20);
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
