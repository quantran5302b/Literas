using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance;

    private List<PlayerCtrl> players = new();

    private List<PlayerCtrl> selectedPlayers = new();

    private int playerMoveCount;

    private int currentIndex = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        //SelectSinglePlayer(0);
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            NextPlayer();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            MoveSelected(Vector2Int.up);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            MoveSelected(Vector2Int.down);
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveSelected(Vector2Int.left);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveSelected(Vector2Int.right);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            UndoManager.Instance.Undo();

        }

    }


    private void NextPlayer()
    {
        currentIndex += playerMoveCount;
        if (currentIndex >= players.Count)
        {
            currentIndex = 0;
        }
        SelectSinglePlayer(currentIndex);
      
    }
    private void SelectSinglePlayer(int index)
    {
        this.ReturnCanMove();
        selectedPlayers.Clear();
        for (int i = 0; i < playerMoveCount; i++)
        {
             index = (currentIndex + i) % players.Count;
            selectedPlayers.Add(players[index]);
            players[index].PlayerModel.PlayerLight(true);
        }
    }
    private void MoveSelected(Vector2Int dir)
    {
        UndoManager.Instance.BeginTurn();

        List<PlayerCtrl> moveOrder = GetMoveOrder(dir);
        foreach(PlayerCtrl a in moveOrder)
        {
            a.PlayerController.canMove = false;
        }
        // Phase 1: Chuẩn bị
        foreach (PlayerCtrl player in moveOrder)
        {
            player.PlayerController.PrepareMove(dir);
        }

        // Phase 2: Kiểm tra
        foreach (PlayerCtrl player in moveOrder)
        {
            player.PlayerController.CheckMove();
        }

        // Phase 3: Thực thi
        foreach (PlayerCtrl player in moveOrder)
        {
            player.PlayerController.ExecuteMove();
        }

        UndoManager.Instance.EndTurn();
    }

    public void Initialize(List<PlayerCtrl> players, int count)
    {
        this.playerMoveCount = count;
        this.players = players;
        SelectSinglePlayer(0);
    }
   
    public bool CanGroupMove(Vector2Int dir)
    {
        foreach (PlayerCtrl player in selectedPlayers)
        {
            Vector2Int targetPos = dir + player.PlayerController.currentPos;

            if (!GridManager.Instance.IsValid(targetPos)) return false;
            CellCtrl cellCtrl = GridManager.Instance.GetCell(targetPos);
            CellRule cellRule = cellCtrl.CellRule;
            if (cellRule != null && !cellRule.CanMove(player.PlayerController)) return false;


            CellCtrl target = GridManager.Instance.GetCell(targetPos);
            PlayerCtrl occupied = target.CellRule.OccupiedBy;

            if (occupied == null)
                continue;

            if (IsSelected(occupied))
                continue;

            return false;
        }

        return true;
    }
    private bool IsSelected(PlayerCtrl player)
    {
        return selectedPlayers.Contains(player);
    }
    private List<PlayerCtrl> GetMoveOrder(Vector2Int dir)
    {
        foreach (PlayerCtrl a in selectedPlayers)
        {
            a.PlayerController.canMove = false;
        }
        List<PlayerCtrl> moveOrder = new List<PlayerCtrl>(selectedPlayers);

        if (dir == Vector2Int.up)
        {
            moveOrder.Sort((a, b) =>
                b.PlayerController.currentPos.y.CompareTo(a.PlayerController.currentPos.y));
        }
        else if (dir == Vector2Int.down)
        {
            moveOrder.Sort((a, b) =>
                a.PlayerController.currentPos.y.CompareTo(b.PlayerController.currentPos.y));
        }
        else if (dir == Vector2Int.left)
        {
            moveOrder.Sort((a, b) =>
                a.PlayerController.currentPos.x.CompareTo(b.PlayerController.currentPos.x));
        }
        else if (dir == Vector2Int.right)
        {
            moveOrder.Sort((a, b) =>
                b.PlayerController.currentPos.x.CompareTo(a.PlayerController.currentPos.x));
        }

        return moveOrder;
    }
    private void ReturnCanMove()
    {
        foreach (PlayerCtrl a in players)
        {
            a.PlayerController.canMove = false;
            a.PlayerModel.PlayerLight(false);
        }
    }
}