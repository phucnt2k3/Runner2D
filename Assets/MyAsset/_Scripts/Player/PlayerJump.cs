using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : ObjMovement
{
    [Header("Player Jump")]
    [SerializeField] protected PlayerCtrl playerCtrl;
    [SerializeField] protected float jumpForce = 7f;
    [SerializeField] protected int countJump = 0;
    [SerializeField] protected bool isJump = false;

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
        jumpForce = playerCtrl.PlayerInfo.jumpForce;
    }

    protected override void GetMovementInfo()
    {
        GetDirection();
    }

    protected virtual void GetDirection()
    {
        isJump = InputManager.Instance.IsJump;
    }

    protected override void MakeMovement()
    {
        Jump();
    }

    protected virtual void Jump()
    {
        if (isJump == false) return;
        isJump = false;

        if (countJump > 1) return;

        countJump++;
        JumpSingle();
    }

    public virtual void JumpSingle()
    {
        if (playerCtrl.PlayerRb.bodyType == RigidbodyType2D.Static) return;
        
        playerCtrl.PlayerRb.velocity = new Vector2(playerCtrl.PlayerRb.velocity.x, jumpForce);
    }

    public virtual void SetJumpCount(int jumpCount) { countJump = jumpCount; }
}
