using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    [SerializeField] private PlayerModel playerModel;
    public PlayerModel PlayerModel { get => playerModel;}

    [SerializeField] private PlayerController playerController;
    public PlayerController PlayerController { get => playerController; }

    private void Awake()
    {
        this.LoadPlayerModel();
        this.LoadPlayerController();
    }
    private void LoadPlayerModel()
    {
        if (!this.playerModel) return;
        this.playerModel = GetComponentInChildren<PlayerModel>();
    }
    private void LoadPlayerController()
    {
        if (!this.playerController) return;
        this.playerController = GetComponentInChildren<PlayerController>();
    }
}
