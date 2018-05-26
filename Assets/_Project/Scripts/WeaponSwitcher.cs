using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwitcher : MonoBehaviour {
    private OVRInput.Controller thisController;
    public bool leftHand = false;
    private bool menuIsSwipable;
    private float menuStickX;
    public ObjectMenuManager menuManager;

    // Use this for initialization
    void Start() {
        if (leftHand)
        {
            thisController = OVRInput.Controller.LTouch;
        }
        else
        {
            thisController = OVRInput.Controller.RTouch;
        }
    }

    // Update is called once per frame
    void Update() {
        if (!leftHand)
        {
            menuStickX = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, thisController).x;
            if (OVRInput.Get(OVRInput.Touch.PrimaryThumbstick, thisController))
            {
                if (menuStickX < 0.45f && menuStickX > -0.45f)
                {
                    menuIsSwipable = true;
                }
                if (menuIsSwipable)
                {
                    if (menuStickX >= 0.45f)
                    {
                        swipeRight();
                        menuIsSwipable = false;
                    }
                    else if (menuStickX <= -0.45f)
                    {
                        swipeLeft();
                        menuIsSwipable = false;
                    }
                }

            }
        }
    }

    private void swipeLeft()
    {
        menuManager.MenuLeft();
    }

    private void swipeRight()
    {
        menuManager.MenuRight();
    }
}
