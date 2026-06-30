using System.Collections.Generic;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public static SelectionManager Instance;

    [SerializeField] private List<PlayerCtrl> players = new();

    private List<PlayerCtrl> selectedPlayers = new();

    [SerializeField] private int playerMoveCount = 1;

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
        SelectSinglePlayer(0);
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
        selectedPlayers.Clear();
        for (int i = 0; i < playerMoveCount; i++)
        {
             index = (currentIndex + i) % players.Count;
            selectedPlayers.Add(players[index]);
        }
    }


    private void MoveSelected(Vector2Int dir)
    {
        foreach (PlayerCtrl player in selectedPlayers)
        {
            player.PlayerController.Move(dir);
        }
    }

}