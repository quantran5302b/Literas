using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorHelper 
{
    public static Color ToUnityColor(EnumColor color)
    {
        return color switch
        {
            EnumColor.Red => Color.red,
            EnumColor.Yellow => Color.yellow,
            EnumColor.Black => Color.black,
            EnumColor.Gray => new Color32(199, 207, 204, 255),
            _ => throw new System.NotImplementedException()
        };
    }
}
