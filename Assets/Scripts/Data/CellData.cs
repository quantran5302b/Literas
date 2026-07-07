using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellData : UndoData
{
    public CellModel cell;
    public EnumColor previousColor;

    public CellData(CellModel cell, EnumColor previousColor)
    {
        this.cell = cell;
        this.previousColor = previousColor;
    }

    public void Undo()
    {
        cell.SetColor(previousColor);
    }
}
