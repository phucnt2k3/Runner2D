using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    private Animator _enemyAnim;
    private SpriteRenderer _enemyRd;
    private EnemyController _enemyController;

    private void Awake()
    {
        _enemyAnim = GetComponent<Animator>();
        _enemyRd = GetComponent<SpriteRenderer>();
        _enemyController = GetComponent<EnemyController>();
    }

    private void LateUpdate()
    {
        ChangeStateAnimation();
    }

    private void ChangeStateAnimation()
    {
        MovementState state;

        if (_enemyController.directionX > 0f)
        {
            state = MovementState.Run;
            _enemyRd.flipX = false;
        }
        else if (_enemyController.directionX < 0f)
        {
            state = MovementState.Run;
            _enemyRd.flipX = true;
        }
        else
            state = MovementState.Idle;

        _enemyAnim.SetInteger("state", (int)state);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _enemyAnim.SetInteger("state", 2);
        }
    }
}

public enum MovementState
{
    Idle,
    Run,
    Hit,
}
