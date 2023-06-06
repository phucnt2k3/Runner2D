using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class PlayerCtrl : ObjCtrl
{
    [Header("Player Ctrl")]
    [SerializeField] private PlayerInfoSO playerInfo; 
    public PlayerInfoSO PlayerInfo => playerInfo;
    [SerializeField] private Rigidbody2D playerRb;
    public Rigidbody2D PlayerRb => playerRb;
    [SerializeField] private PlayerMove playerMove;
    public PlayerMove PlayerMove => playerMove;
    [SerializeField] private PlayerJump playerJump;
    public PlayerJump PlayerJump => playerJump;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadRigidBody();
        LoadPlayerMove();
        LoadPlayerJump();
        LoadPlayerInfo();
    }

    protected virtual void LoadPlayerInfo()
    {
        if (playerInfo != null) return;

        var objs = Resources.LoadAll("_Config", typeof(PlayerInfoSO));
        if (objs.Length > 1) 
            Debug.LogError(transform.name + ": Resources LoadAll 1 more PlayerInfoSO", gameObject);

        playerInfo = (PlayerInfoSO) objs[0];
        Debug.LogWarning(transform.name + ": Load PlayerInfoSO", gameObject);
    }

    protected virtual void LoadRigidBody()
    {
        if (playerRb != null) return;

        playerRb = GetComponent<Rigidbody2D>();
        Debug.LogWarning(transform.name + ": Load Rigidbody2D", gameObject);
    }

    protected virtual void LoadPlayerMove()
    {
        if (playerMove != null) return;

        playerMove = transform.GetComponentInChildren<PlayerMove>();
        Debug.LogWarning(transform.name + ": Load PlayerMove", gameObject);
    }

    protected virtual void LoadPlayerJump()
    {
        if (playerJump != null) return;

        playerJump = transform.GetComponentInChildren<PlayerJump>();
        Debug.LogWarning(transform.name + ": Load PlayerJump", gameObject);
    }
}
