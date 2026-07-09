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

    }
    private void Start()
    {
        isUndoing = true;

        ApplyColor();

        isUndoing = false;

    }
    public void SetColor(EnumColor newColor)
    {
        if (color == newColor) return;
        if (newColor == EnumColor.Gray) return;
        if (!isUndoing)
        {
            CellUndoData data = new CellUndoData(this, color);
            UndoManager.Instance.AddData(data);
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
    public void ChangeByPlayer(PlayerCtrl player)
    {
        SetColor(player.PlayerModel.CenterColor);
    }
}
