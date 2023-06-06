using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : ObjMovement
{
    [Header("Player Move")]
    [SerializeField] protected PlayerCtrl playerCtrl;
    [SerializeField] protected float speed = 11f;
    [SerializeField] protected float directionX = 0f;
    public float DirectionX => directionX;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerCtrl();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (playerCtrl != null) return;

        playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
        Debug.LogWarning(transform.name + ": Load Player Ctrl", gameObject);
    }

    private void Awake()
    {
        speed = playerCtrl.PlayerInfo.moveSpeed;
    }

    protected override void GetMovementInfo()
    {
        GetDirection();
    }

    protected virtual void GetDirection()
    {
        directionX = InputManager.Instance.DirectionX;
    }

    protected override void MakeMovement()
    {
        Move();
    }

    protected virtual void Move()
    {
        if(playerCtrl.PlayerRb.bodyType != RigidbodyType2D.Static)
            playerCtrl.PlayerRb.velocity = new Vector2 (directionX * speed, playerCtrl.PlayerRb.velocity.y);
    }
}
