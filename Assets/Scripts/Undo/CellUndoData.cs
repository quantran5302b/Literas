using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellUndoData : UndoData
{
    public CellModel cell;
    public EnumColor previousColor;

    public CellUndoData(CellModel cell, EnumColor previousColor)
    {
        this.cell = cell;
        this.previousColor = previousColor;
    }

    public void Undo()
    {
        Debug.Log(previousColor.ToString());
        cell.RestoreColor(previousColor);
    }
}
