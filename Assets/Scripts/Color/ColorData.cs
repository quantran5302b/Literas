using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorData : MonoBehaviour
{
    [SerializeField]private EnumColor color;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        this.LoadSpriteRenderer();
    }
    private void Start()
    {
        if(color == EnumColor.Gray)
        {
            SetColor(EnumColor.Black);
        }
    }

    public void SetColor(EnumColor newColor)
    {
        color = newColor;

        switch (color)
        {
            case EnumColor.Red:
                spriteRenderer.color = Color.red;
                break;

            case EnumColor.Yellow:
                spriteRenderer.color = Color.yellow;
                break;
            case EnumColor.Black:
                spriteRenderer.color = Color.black;
                break;
        }
    }
    public EnumColor GetColor()
    {
        return color;
    }
    private void LoadSpriteRenderer()
    {
        if (this.spriteRenderer != null) return;
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }

}
