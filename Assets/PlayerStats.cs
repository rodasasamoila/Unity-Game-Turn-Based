using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats
{
    public int Stamina=2;
    private static PlayerStats instance = null;
    private PlayerStats()
    {

    }

    public static PlayerStats Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PlayerStats();
            }
            return instance;
        }
    }
}
