using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : PlayerAbstract
{
    [Header("Player Animator")]
    [SerializeField] private float directionX = 0f;
    [SerializeField] private float velocityY = 0f;
    [SerializeField] private Animator playerAnim;
    [SerializeField] private SpriteRenderer playerRd;
    private enum MovementState
    {
        Idle,
        Run,
        Jump,
        Fall,
        DoubleJump,
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadAnimator();
        LoadRenderer();
    }

    protected virtual void LoadAnimator()
    {
        if (playerAnim != null) return;

        playerAnim = GetComponent<Animator>();
        Debug.LogWarning(transform.name + ": Load Animator", gameObject);
    }

    protected virtual void LoadRenderer()
    {
        if (playerRd != null) return;

        playerRd = transform.GetComponent<SpriteRenderer>();
        Debug.LogWarning(transform.name + ": Load SpriteRenderer", gameObject);
    }


    private void Update()
    {
        directionX = playerCtrl.PlayerMove.DirectionX;
        velocityY = playerCtrl.PlayerRb.velocity.y;
    }

    private void FixedUpdate()
    {
        ChangeStateAnimation();
    }

    private void ChangeStateAnimation()
    {
        MovementState state;

        if (directionX > 0f)
        {
            state = MovementState.Run;
            playerRd.flipX = false;
        }
        else if (directionX < 0f)
        {
            state = MovementState.Run;
            playerRd.flipX = true;
        }
        else state = MovementState.Idle;

        if (velocityY > .1f) state = MovementState.Jump;
        else if (velocityY < -.1f) state = MovementState.Fall;

        playerAnim.SetInteger("state", (int)state);
    }
}
