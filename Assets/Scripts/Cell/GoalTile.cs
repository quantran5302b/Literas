using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTile : Cell
{
    public LevelManager LevelManager;

    public override void OnEnter(PlayerController player)
    {
        LevelManager.Win();
    }
}
