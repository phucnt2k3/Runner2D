using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : ObjMovement
{
    [Header("Enemy Move Reverse By Time")]
    [SerializeField] protected EnemyCtrl enemyCtrl;
    [SerializeField] protected float speed = 11f;
    [SerializeField] protected float directionX = 1f;
    public float DirectionX => directionX;
    [SerializeField] protected float reverseTimer = 0f;
    [SerializeField] protected float reverseTime = 2f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerCtrl();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (enemyCtrl != null) return;

        enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.LogWarning(transform.name + ": Load EnemyCtrl", gameObject);
    }

    private void Awake()
    {
        speed = enemyCtrl.EnemyInfo.moveSpeed;
    }

    protected override void GetMovementInfo()
    {
        GetDirection();
    }

    protected virtual void GetDirection()
    {

        if (reverseTimer > reverseTime)
        {
            reverseTimer = 0;
            directionX = -directionX;
        }

        reverseTimer += Time.deltaTime;
    }

    protected override void MakeMovement()
    {
        Move();
    }

    protected virtual void Move()
    {
        if (enemyCtrl.EnemyRb.bodyType != RigidbodyType2D.Static)
            enemyCtrl.EnemyRb.velocity = new Vector2(directionX * speed, enemyCtrl.EnemyRb.velocity.y);
    }
}
