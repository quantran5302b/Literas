using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerController : MonoBehaviour
{
    private GridManager grid;

    public Vector2Int currentPos;
    private Vector2Int nextPos;

    public CellCtrl cellCtrl;

    [SerializeField] private PlayerCtrl playerCtrl;
    public PlayerCtrl PlayerCtrl { get => playerCtrl; }


    private bool isUndoing;


    public Vector2Int targetPos;
    public bool canMove;

    private void Awake()
    {
        this.LoadPlayerCtrl();
    }
    private void Start()
    {
        grid = GridManager.Instance;
        isUndoing = true;

        SnapCell(currentPos);

        isUndoing = false;
    }

   //public void Move(Vector2Int dir)
   // {
   //     Vector2Int targetPos = currentPos + dir;
   //     SnapCell(targetPos);
   // }

    public void PrepareMove(Vector2Int dir)
    {
        targetPos = currentPos + dir;
        canMove = false;
    }


    public void CheckMove()
    {
        if (!grid.IsValid(targetPos))
        {
            canMove = false;
            return;
        }

        CellCtrl targetCell = grid.GetCell(targetPos);

        CellRule rule = targetCell.CellRule;

        if (rule != null && !rule.CanMove(this))
        {
            canMove = false;
            return;
        }
        PlayerCtrl occupied = targetCell.CellRule.OccupiedBy;
        if(occupied != null)
        {
            if(occupied.PlayerController.canMove != true){
                canMove = false;
                return;
            } 
            //else
            //{

            //}
            //    canMove = false;
            //return;
        }

        canMove = true;
    }

    public void ExecuteMove()
    {
        if (!canMove)
            return;

        SnapCell(targetPos);
    }


    private void SnapCell(Vector2Int pos)
    {
        nextPos = pos;
        cellCtrl = grid.GetCell(pos);
        if (cellCtrl == null)
        {
            Debug.LogError("Cell null");
            return;
        }
        if (!isUndoing)
        {
            PlayerUndoData data =
                new PlayerUndoData(this, currentPos);
            UndoManager.Instance.AddData(data);
        }
        transform.parent.position = cellCtrl.gameObject.transform.position;
        cellCtrl.CellModel.ChangeByPlayer(playerCtrl);
        cellCtrl.CellRule.SetOccupiedBy(PlayerCtrl);
        if (nextPos == currentPos) return;
        CellCtrl oldCell = grid.GetCell(currentPos);
        oldCell.CellRule.SetOccupiedBy(null);
        currentPos = nextPos;

        if (GoalManager.Instance.CheckWin())
        {
            Debug.Log("win");
        }

    }
    private void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GetComponentInParent<PlayerCtrl>();
    }
    public void UndoMove(Vector2Int pos)
    {
        isUndoing = true;
        SnapCell(pos);
        isUndoing = false;
    }
    public void Initialize(PlayerSpawnData data)
    {
        currentPos = data.position;
    }


}