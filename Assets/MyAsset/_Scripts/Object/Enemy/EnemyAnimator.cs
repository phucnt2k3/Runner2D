using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : EnemyAbstract
{
    [Header("Enemy Animator")]
    [SerializeField] private float directionX = 0f;
    [SerializeField] private Animator enemyAnim;
    [SerializeField] private SpriteRenderer enemyRd;
    private enum MovementState
    {
        Idle,
        Run,
        Hit,
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadAnimator();
        LoadRenderer();
    }

    protected virtual void LoadAnimator()
    {
        if (enemyAnim != null) return;

        enemyAnim = GetComponent<Animator>();
        Debug.LogWarning(transform.name + ": Load Animator", gameObject);
    }

    protected virtual void LoadRenderer()
    {
        if (enemyRd != null) return;

        enemyRd = transform.GetComponent<SpriteRenderer>();
        Debug.LogWarning(transform.name + ": Load SpriteRenderer", gameObject);
    }

    private void Update()
    {
        directionX = enemyCtrl.EnemyMove.DirectionX;
    }

    private void LateUpdate()
    {
        ChangeStateAnimation();
    }

    private void ChangeStateAnimation()
    {
        MovementState state;

        if (directionX > 0f)
        {
            state = MovementState.Run;
            enemyRd.flipX = false;
        }
        else if (directionX < 0f)
        {
            state = MovementState.Run;
            enemyRd.flipX = true;
        }
        else
            state = MovementState.Idle;

        enemyAnim.SetInteger("state", (int)state);
    }
}
