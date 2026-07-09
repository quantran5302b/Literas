using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GridManager grid;

    public Vector2Int currentPos;
    public Vector2Int nextPos;

    public CellCtrl cellCtrl;


    [SerializeField] private PlayerCtrl playerCtrl;

    public PlayerCtrl PlayerCtrl { get => playerCtrl; }


    private bool isUndoing;

    private void Awake()
    {
        this.LoadPlayerCtrl();
    }
    private void Start()
    {
        isUndoing = true;

        SnapCell(currentPos);

        isUndoing = false;
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.W)) Move(Vector2Int.up);
        //if (Input.GetKeyDown(KeyCode.S)) Move(Vector2Int.down);
        //if (Input.GetKeyDown(KeyCode.A)) Move(Vector2Int.left);
        //if (Input.GetKeyDown(KeyCode.D)) Move(Vector2Int.right);
        //if (Input.GetKeyDown(KeyCode.Z))
        //{
        //    Undo();
        //}
    }

   public void Move(Vector2Int dir)
    {
        Vector2Int targetPos = currentPos + dir;

        if (!grid.IsValid(targetPos)) return;
         cellCtrl = grid.GetCell(targetPos);
        CellRule cellRule = cellCtrl.CellRule;
        if (cellRule != null && !cellRule.CanMove(this)) return;
        //nextPos = targetPos;
   
        SnapCell(targetPos);
       
        //if (cellRule != null)
        //    cellRule.OnEnter(this);
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

            //UndoManager.Instance.SaveMove(data);
            UndoManager.Instance.AddData(data);
        }


        transform.parent.position = cellCtrl.gameObject.transform.position;
        //PlayerCtrl.PlayerModel.ChangeColorCell(cellCtrl, PlayerCtrl.PlayerModel.CenterColor);
        /////
        cellCtrl.CellModel.ChangeByPlayer(playerCtrl);
        //--------------------------
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

    //public void Undo()
    //{
    //    //MoveData data = UndoManager.Instance.Undo();

    //    if (data == null)
    //        return;

    //    isUndoing = true;

    //    data.player.SnapCell(data.previousPos);

    //    isUndoing = false;
    //}
    public void UndoMove(Vector2Int pos)
    {
        isUndoing = true;
        SnapCell(pos);
        isUndoing = false;
    }



}