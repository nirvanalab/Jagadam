using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GamePref {

    private static string gameTypeSelected;

    public static string GameTypeSelected
    {
        get
        {
            return gameTypeSelected;
        }
        set
        {
            gameTypeSelected = value;
        }
    }

}
