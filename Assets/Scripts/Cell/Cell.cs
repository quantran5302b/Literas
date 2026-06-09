using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Vector2Int gridPos;
    public GridManager grid;

    private CellCtrl cellCtrl;

    public CellCtrl CellCtrl { get => cellCtrl;}

    private void Awake()
    {
        this.LoadCellCtrl();
    }
    protected virtual void Start()
    {
       
    }

    public virtual bool CanMove(PlayerController player)
    {
        if (CheckCanMove(player))
        {
            return true;
        }
        return false;
    }

    public virtual void OnEnter(PlayerController player)
    {

    }

    private void LoadCellCtrl()
    {
        if (this.cellCtrl != null) return;
        this.cellCtrl = GetComponentInParent<CellCtrl>();  

    }
    //private void ChangColor(EnumColor color)
    //{
    //    cellCtrl.ColorData.SetColor(color);
    //}
    private bool CheckCanMove(PlayerController player)
    {
        if (cellCtrl.ColorData.GetColor() == EnumColor.Black || player.Color == EnumColor.Black)
        {
            return true;
        }
        if (cellCtrl.ColorData.GetColor() == player.Color)
        {
            return true;
        }
        return false;
    }


}
