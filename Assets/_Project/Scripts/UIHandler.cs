using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour {

    public void PlayRobot()
    {
        //GamePref.GameTypeSelected = "RobotGame";
        GamePref.GameTypeSelected = Constants.RobotGame;
        SceneManager.LoadScene("Battle");     
    }

    public void PlayZombie()
    {
        GamePref.GameTypeSelected = Constants.ZombieGame;
        SceneManager.LoadScene("Battle");
      
    }

    public void PlayRobotAndZombie()
    {
        GamePref.GameTypeSelected = Constants.RobotZombieGame;
        SceneManager.LoadScene("Battle");
      
    }

    public void ReplayGame()
    {
        SceneManager.LoadScene("Battle");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
