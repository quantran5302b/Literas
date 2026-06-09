using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellCtrl : MonoBehaviour
{
    [SerializeField] private ColorData colorData;

    public ColorData ColorData { get => colorData;}

    private void Awake()
    {
        this.LoadColorData();
    }
    private void LoadColorData()
    {
        if (this.colorData != null) return;
        this.colorData = GetComponentInChildren<ColorData>();
    }
}
