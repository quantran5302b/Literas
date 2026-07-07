using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellModel : MonoBehaviour
{
    [SerializeField] private SpriteRenderer model;

    [SerializeField] private EnumColor color;

    public EnumColor Color { get => color; }

    private bool isUndoing;
    private void Awake()
    {
        this.LoadModel();
        //SetColor(color);

    }
    private void Start()
    {
        ApplyColor();
    }
    private void Update()
    {
        //SetColor(color);
    }
    public void SetColor(EnumColor newColor)
    {
        if (color == newColor) return;
        if (!isUndoing)
        {
            CellData data = new CellData(this, newColor);
            UndoManager.Instance.AddData(data) ;
        }
        color = newColor;
        ApplyColor();

    }
    public void RestoreColor(EnumColor oldColor)
    {
        color = oldColor;
        ApplyColor();
    }

    private void ApplyColor()
    {
        isUndoing = true;
        model.color = ColorHelper.ToUnityColor(color);
        isUndoing = false;
    }
    private void LoadModel()
    {
        if (model) return;
        this.model = GetComponent<SpriteRenderer>();
    }
}
