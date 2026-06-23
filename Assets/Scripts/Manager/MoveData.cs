using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveData 
{
    public PlayerController player;
    public Vector2Int previousPos;
    //public CellModel cellModel;
    //public EnumColor cellColor;

    public MoveData(PlayerController player, Vector2Int previousPos)
    {
        this.player = player;
        this.previousPos = previousPos;
    }
}
