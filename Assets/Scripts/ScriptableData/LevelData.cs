using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LevelData", menuName = "Literas/ScriptableData")]
public class LevelData : ScriptableObject
{
    [Header("Grid")]
    public int width;
    public int height;

    [Header("Cells")]
    public List<CellData> cells = new();

    [Header("Players")]
    public List<PlayerSpawnData> players = new();

    [Header("Goals")]
    public List<GoalSpawnData> goals = new();
}