using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalCtrl : MonoBehaviour
{
    private CellCtrl cellCtrl;

    public CellCtrl CellCtrl => cellCtrl;

    public Vector2Int currentPos;

    //public GridManager grid;

    private void Start()
    {
        //this.SnapCell(currentPos);
    }

    public bool IsCompleted()
    {
        return cellCtrl.CellRule.OccupiedBy != null;
    }

    public void SnapCell(Vector2Int pos)
    {
         cellCtrl = GridManager.Instance.GetCell(pos);
        if (cellCtrl == null)
        {
            Debug.LogError("Cell null");
            return;
        }
        transform.position = cellCtrl.gameObject.transform.position;
    }
}
