using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalModel : MonoBehaviour
{
    public Vector2Int currentPos;


    private void Start()
    {
        this.SnapCell(currentPos);
    }

    private void SnapCell(Vector2Int pos)
    {
       CellCtrl cellCtrl = GridManager.Instance.GetCell(pos);
        if (cellCtrl == null)
        {
            Debug.LogError("Cell null");
            return;
        }
        transform.parent.position = cellCtrl.gameObject.transform.position;
    }
}
