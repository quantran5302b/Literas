using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Vector2Int gridPos;
    public GridManager grid;

    [SerializeField] EnumColor color;

    public EnumColor Color { get => color;}

    protected virtual void Start()
    {
       
        //grid.RegisterCell(this, gridPos);
        SnapToGrid();
    }
    void SnapToGrid()
    {
        //this.gridPos = grid.GridToWorld(gridPos);
        //this.gridPos = new Vector2Int(x, y);
    }

    public virtual bool CanMove(PlayerController player)
    {
        if (color == player.Color)
        {
            Debug.Log("dung");
            return true;
        }
        Debug.Log("sai");
        return false;
    }

    public virtual void OnEnter(PlayerController player)
    {

    }
    private void ChangeColor(PlayerController player)
    {
        //if
    }

}
