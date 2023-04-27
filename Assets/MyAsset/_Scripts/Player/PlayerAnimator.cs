using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private enum MovementState
    {
        Idle,
        Run,
        Jump,
        Fall,
        DoubleJump,
    }

    private PlayerController _playerController;
    private Animator _playerAnim;
    private SpriteRenderer _playerRd;
    private Rigidbody2D _playerRb;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        _playerAnim = GetComponent<Animator>();
        _playerRd = GetComponent<SpriteRenderer>();
        _playerRb = GetComponent<Rigidbody2D>();
    }

    private void LateUpdate()
    {
        ChangeStateAnimation();
    }

    private void ChangeStateAnimation()
    {
        MovementState state;

        if (_playerController.directionX > 0f)
        {
            state = MovementState.Run;
            _playerRd.flipX = false;
        }
        else if (_playerController.directionX < 0f)
        {
            state = MovementState.Run;
            _playerRd.flipX = true;
        }
        else
            state = MovementState.Idle;

        if (_playerRb.velocity.y > .1f)
            state = MovementState.Jump;
        else if (_playerRb.velocity.y < -.1f)
            state = MovementState.Fall;

        _playerAnim.SetInteger("state", (int)state);
    }
}
