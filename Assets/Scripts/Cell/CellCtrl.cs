using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellCtrl : MonoBehaviour
{
    [SerializeField] private ColorData colorData;

    public ColorData ColorData { get => colorData;}

    [SerializeField] private CellModel cellModel;
    public CellModel CellModel { get => cellModel; }

    [SerializeField] private CellRule cellRule;
    public CellRule CellRule { get => cellRule; }
    private void Awake()
    {
        this.LoadColorData();
        this.LoadCellModel();
        this.LoadCellRule();
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
    private void LoadCellRule()
    {
        if (cellRule) return;
        this.cellRule = GetComponentInChildren<CellRule>();
    }

}
