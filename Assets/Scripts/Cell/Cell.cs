using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{
    public Vector2Int gridPos;
    public GridManager grid;

    [SerializeField] private CellCtrl cellCtrl;

    public CellCtrl CellCtrl { get => cellCtrl; }

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
        PlayerCtrl playerCtrl = player.GetComponentInParent<PlayerCtrl>();
        if (cellCtrl.CellModel.Color == EnumColor.Gray)
        {
            return true;
        }
        if (playerCtrl.PlayerModel.ContainsColor(cellCtrl.CellModel.Color))
        {
            return true;
        }
        return false;
    }


}
