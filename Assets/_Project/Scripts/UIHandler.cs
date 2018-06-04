using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour {

    public void ButtonBegin()
    {
        Debug.Log("Begin Button Clicked");
        SceneManager.LoadScene("Battle");
    }

    public void ButtonExit()
    {
        Debug.Log("Exit Button Clicked");
        Application.Quit();
    }
}
