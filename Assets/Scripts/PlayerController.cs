using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GridManager grid;

    public Vector2Int currentPos;

    [SerializeField]
    private Vector2Int startPos;

    public Cell cell;

    [SerializeField]private EnumColor color;

    public EnumColor Color { get => color;}

    private void Start()
    {
        //UpdatePosition();
        this.SnapCell(startPos);
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

         cell = grid.GetCell(targetPos);
        if (cell != null && !cell.CanMove(this)) return;

        currentPos = targetPos;
   
        SnapCell(currentPos);

        if (cell != null)
            cell.OnEnter(this);
    }

    private void SnapCell(Vector2Int pos)
    {
        cell = grid.GetCell(pos);
        if (cell == null)
        {
            Debug.LogError("Cell null");
            return;
        }
        transform.position = cell.gameObject.transform.position;
    }
    private void ChangeColorCell(Cell cell)
    { 
        
    }
}