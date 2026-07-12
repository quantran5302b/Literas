using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    [Header("Level")]
    [SerializeField] private LevelData levelData;

    [Header("Managers")]
    [SerializeField] private GridManager gridManager;

    [Header("Prefabs")]
    [SerializeField] private PlayerCtrl playerPrefab;
    [SerializeField] private GoalCtrl goalPrefab;

    private void Start()
    {
        LoadLevel();
    }

    private void LoadLevel()
    {
        CreateGrid();
        SetupCells();
        SpawnGoals();
        SpawnPlayers();
    }

    private void CreateGrid()
    {
        gridManager.CreateGrid(levelData.gridData);
    }

    private void SetupCells()
{
    foreach (CellData data in levelData.cells)
    {
        CellCtrl cell = gridManager.GetCell(data.position);

        if (cell == null)
            continue;

        cell.CellModel.RestoreColor(data.color);
    }
}

    private void SpawnGoals()
    {
        List<GoalCtrl> goals = new List<GoalCtrl>();
        foreach (GoalSpawnData data in levelData.goals)
        {

            GoalCtrl goal = Instantiate(goalPrefab);
            goal.SnapCell(data.position);

            goals.Add(goal);
        }
        GoalManager.Instance.Initialize(goals);
    }
    private void SpawnPlayers()
    {
        List<PlayerCtrl> lstPlayer = new List<PlayerCtrl>();
        foreach (PlayerSpawnData data in levelData.players)
        {
            PlayerCtrl player = Instantiate(playerPrefab);

            PlayerController controller = player.PlayerController;

            //controller.grid = gridManager;
            //controller.currentPos = data.position;
            controller.Initialize(data);

            player.PlayerModel.SetColor(
                data.borderColor,
                data.middleColor,
                data.centerColor);
            lstPlayer.Add(player);
        }
        SelectionManager.Instance.Initialize(lstPlayer , levelData.playerMoveCount);
    }
}
