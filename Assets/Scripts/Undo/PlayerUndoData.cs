using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUndoData : UndoData
{
    public PlayerController player;
    public Vector2Int previousPos;

    public PlayerUndoData(PlayerController player, Vector2Int previousPos)
    {
        this.player = player;
        this.previousPos = previousPos;
    }

    public void Undo()
    {
        player.UndoMove(previousPos);
    }
}
