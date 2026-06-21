using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockTile : CellRule
{
    public override bool CanMove(PlayerController player)
    {
        return false;
    }
}
