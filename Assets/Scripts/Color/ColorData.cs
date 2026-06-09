using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorData : MonoBehaviour
{
    [SerializeField]private EnumColor color;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private void Start()
    {
        if(color == EnumColor.None)
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
                color = EnumColor.Red;
                break;

            case EnumColor.Yellow:
                spriteRenderer.color = Color.yellow;
                color = EnumColor.Yellow;
                break;
            case EnumColor.Black:
                spriteRenderer.color = Color.black;
                color = EnumColor.Black;
                break;
        }
    }
    public EnumColor GetColor()
    {
        return color;
    }
}
