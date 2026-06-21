using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellModel : MonoBehaviour
{
    [SerializeField] private SpriteRenderer model;

    [SerializeField] private EnumColor color;

    public EnumColor Color { get => color; }

    private void Awake()
    {
        this.LoadModel();
        SetColor(color);

    }
    private void Update()
    {
        SetColor(color);
    }
    public void SetColor(EnumColor color)
    {
        this.color = color;
        model.color = ColorHelper.ToUnityColor(color);
    }
    private void LoadModel()
    {
        if (model) return;
        this.model = GetComponent<SpriteRenderer>();
    }
}
