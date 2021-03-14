using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;
using UnityEngine;

public sealed class CombatProcessor
{
    private static CombatProcessor instance = null;
    public List<EnemyMovement> enemies = new List<EnemyMovement>();
    public GameObject player;

    private CombatProcessor()
    {

    }

    public static CombatProcessor Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new CombatProcessor();
            }
            return instance;
        }
    }
    public void TurnCombat(GameObject player)
    {
        Console.WriteLine(enemies.Count);

        foreach (EnemyMovement enemy in enemies)
        {
            enemy.followPlayer(player.transform.position);
           
        }
    }

}
