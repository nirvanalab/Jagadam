using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMenuManager : MonoBehaviour
{

    public List<GameObject> objectList;
    public List<GameObject> objectPrefabList;
    public int currentObject = 0;
    private GameObject activeGun; 
 

    // Use this for initialization
    void Start()
    {
       // Debug.Log("Object Menu Manager Start");
        foreach (Transform child in transform)
        {
           // Debug.Log("Adding Object");
            objectList.Add(child.gameObject);
        }
    }

    
    public void MenuLeft()
    {
        objectList[currentObject].SetActive(false);
        currentObject--;
        if (currentObject < 0)
        {
            currentObject = objectList.Count - 1;
        }
        GameObject gun =  objectList[currentObject];
        gun.SetActive(true);
        activeGun = gun;
    }

    public void MenuRight()
    {
        objectList[currentObject].SetActive(false);
        currentObject++;
        if (currentObject > objectList.Count-1)
        {
            currentObject = 0;
        }
        GameObject gun = objectList[currentObject];
        gun.SetActive(true);
        activeGun = gun;
    }

    public void SpawnCurrentObject()
    {
       Instantiate(objectPrefabList[currentObject], 
            objectList[currentObject].transform.position,
             objectList[currentObject].transform.rotation);
     
    }

    public GameObject getActiveWeapon()
    {
        return activeGun;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
