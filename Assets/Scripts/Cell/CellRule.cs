using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class CellRule : MonoBehaviour
{
    public Vector2Int gridPos;
    public GridManager grid;
    [SerializeField]private  PlayerCtrl playerCtrl;

    [SerializeField] private CellCtrl cellCtrl;
    public CellCtrl CellCtrl { get => cellCtrl; }

    [SerializeField] private PlayerCtrl OccupiedBy;

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
    private bool CheckCanMove(PlayerController player)
    {
        if (OccupiedBy !=null )
        {
            return false;
        }
        if (cellCtrl.CellModel.Color == EnumColor.Gray)
        {
            return true;
        }
        if (player.PlayerCtrl.PlayerModel.ContainsColor(cellCtrl.CellModel.Color))
        {
            return true;
        }
        
        return false;
    }

    public void SetOccupiedBy(PlayerCtrl player)
    {
        OccupiedBy = player;
        //Debug.Log(player);
    }

}
