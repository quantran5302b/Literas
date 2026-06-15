using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellCtrl : MonoBehaviour
{
    [SerializeField] private ColorData colorData;

    public ColorData ColorData { get => colorData;}

    [SerializeField] private CellModel cellModel;
    public CellModel CellModel { get => cellModel; }

    private void Awake()
    {
        this.LoadColorData();
        this.LoadCellModel();
    }
    private void LoadColorData()
    {
        if (colorData) return;
        this.colorData = GetComponentInChildren<ColorData>();
    }
    private void LoadCellModel()
    {
        if (cellModel) return;
        this.cellModel = GetComponentInChildren<CellModel>();
    }
}
