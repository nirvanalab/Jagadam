using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour {

    [SerializeField]
    public int pistolAmmo = 25;
    [SerializeField]
    public int shortGunAmmo = 10;
    [SerializeField]
    public int assaultRifleAmmo = 50;

    public Dictionary<string, int> ammoMap;

    private void Awake()
    {
        ammoMap = new Dictionary<string, int>
        {
            {Constants.Pistol,pistolAmmo},
             {Constants.Shotgun,shortGunAmmo},
              {Constants.AssaultRifle,assaultRifleAmmo}
        };
    }

   public void AddAmmo(string tag, int ammo)
    {
        ammoMap[tag] += ammo;
    }

    public void ConsumeAmmo(string tag)
    {
        if(ammoMap[tag] <= 0)
        {
            return;
        }

        ammoMap[tag] -= 1;
    }

    public bool HasAmmo(string tag)
    {
        return ammoMap[tag] > 0;
    }

   public int GetAmmo(string tag)
    {
        return ammoMap[tag];
    }

    // Update is called once per frame
    void Update () {
		
	}
}
