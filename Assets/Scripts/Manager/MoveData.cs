using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveData : UndoData
{
    public PlayerController player;
    public Vector2Int previousPos;

    public MoveData(PlayerController player, Vector2Int previousPos)
    {
        this.player = player;
        this.previousPos = previousPos;
    }

    public void Undo()
    {
        player.UndoMove(previousPos);
    }
}
