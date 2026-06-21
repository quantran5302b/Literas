using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GridManager grid;

    public Vector2Int currentPos;
    public Vector2Int nextPos;

    public CellCtrl cellCtrl;


    [SerializeField] private PlayerCtrl playerCtrl;

    public PlayerCtrl PlayerCtrl { get => playerCtrl; }

    private void Awake()
    {
        this.LoadPlayerCtrl();
    }
    private void Start()
    {
        //currentPos = startPos;
        this.SnapCell(currentPos);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) Move(Vector2Int.up);
        if (Input.GetKeyDown(KeyCode.S)) Move(Vector2Int.down);
        if (Input.GetKeyDown(KeyCode.A)) Move(Vector2Int.left);
        if (Input.GetKeyDown(KeyCode.D)) Move(Vector2Int.right);
    }

    void Move(Vector2Int dir)
    {
        Vector2Int targetPos = currentPos + dir;

        if (!grid.IsValid(targetPos)) return;
         cellCtrl = grid.GetCell(targetPos);
        CellRule cellRule = cellCtrl.CellRule;
        if (cellRule != null && !cellRule.CanMove(this)) return;
        //nextPos = targetPos;
   
        SnapCell(targetPos);
       
        if (cellRule != null)
            cellRule.OnEnter(this);
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
        transform.position = cellCtrl.gameObject.transform.position;
        PlayerCtrl.PlayerModel.ChangeColorCell(cellCtrl, PlayerCtrl.PlayerModel.CenterColor);
        cellCtrl.CellRule.SetOccupiedBy(PlayerCtrl);

        if (nextPos == currentPos) return;
        CellCtrl cellcu = grid.GetCell(currentPos);
        cellcu.CellRule.SetOccupiedBy(null);
        currentPos = nextPos;

    }
    private void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GetComponentInParent<PlayerCtrl>();
    }
    

}