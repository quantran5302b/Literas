using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class GridManager : MonoBehaviour
{
    public CellCtrl[,] cells;
    public int width ;
    public int height ;

    public float cellSize  ;
    public GameObject cellColor;

    void Awake()
    {
        cells = new CellCtrl[width, height];
        float offsetX = (width - 1) * cellSize * 0.5f;
        float offsetY = (height - 1) * cellSize * 0.5f;
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {

               GameObject obj =  Instantiate(cellColor, new Vector3(x * cellSize - offsetX,y * cellSize - offsetY,0), Quaternion.identity,transform.root);
                CellRule cell = obj.GetComponentInChildren<CellRule>();
                cell.grid = this;
                cell.gridPos = new Vector2Int(x, y);
                cells[x, y] = cell.CellCtrl;
            }
        }
    }
    public Vector3 GridToWorld(Vector2Int pos)//chuyển đổi position
    {
        return new Vector3(pos.x * cellSize, pos.y * cellSize, 0);
    }

    public bool IsValid(Vector2Int pos) // check gioi han
    {
        return pos.x >= 0 && pos.x < width &&
               pos.y >= 0 && pos.y < height;
    }

    public CellCtrl GetCell(Vector2Int pos) // infor cell
    {
        if (!IsValid(pos)) return null;
        return cells[pos.x, pos.y];
    }
    //public void RegisterCell(Cell cell, Vector2Int pos)
    //{
    //    cells[pos.x, pos.y] = cell;
    //}
    

}

