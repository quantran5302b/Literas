using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{
    [SerializeField] private SpriteRenderer model_1;
    [SerializeField] private SpriteRenderer model_2;
    [SerializeField] private SpriteRenderer model_3;

    [SerializeField] private EnumColor borderColor; 
    [SerializeField] private EnumColor middleColor;
    [SerializeField] private EnumColor centerColor;

    [SerializeField] private PlayerCtrl playerCtrl;

    public EnumColor BorderColor { get => borderColor; }
    public EnumColor MiddleColor { get => middleColor; }
    public EnumColor CenterColor { get => centerColor; }

    private void Awake()
    {
        this.LoadPlayerCtrl();
        this.SetColorModel();
    }
    private void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = GetComponentInParent<PlayerCtrl>();
    }
    public void SetColorModel()
    {
        model_1.color = ColorHelper.ToUnityColor(BorderColor);
        model_2.color = ColorHelper.ToUnityColor(MiddleColor);
        model_3.color = ColorHelper.ToUnityColor(CenterColor);
    }

    public bool ContainsColor(EnumColor color)
    {
        return color == borderColor ||
               color == middleColor || 
               color == centerColor;
    }
    //private void SetColor

}
