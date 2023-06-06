using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : ObjCtrl
{
    [Header("Enemy Ctrl")]
    [SerializeField] private EnemyInfoSO enemyInfo;
    public EnemyInfoSO EnemyInfo => enemyInfo;
    [SerializeField] private Rigidbody2D enemyRb;
    public Rigidbody2D EnemyRb => enemyRb;
    [SerializeField] private EnemyMove enemyMove;
    public EnemyMove EnemyMove => enemyMove;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadRigidBody();
        LoadEnemyInfo();
        LoadEnemyMove();
    }

    protected virtual void LoadEnemyMove()
    {
        if (enemyMove != null) return;

        enemyMove = transform.GetComponentInChildren<EnemyMove>();
        Debug.LogWarning(transform.name + ": Load EnemyMove", gameObject);
    }

    protected virtual void LoadEnemyInfo()
    {
        if (enemyInfo != null) return;

        var objs = Resources.LoadAll("_Config/Enemy", typeof(EnemyInfoSO));
        if (objs.Length > 1)
            Debug.LogError(transform.name + ": Resources LoadAll 1 more EnemyInfoSO", gameObject);

        enemyInfo = (EnemyInfoSO) objs[0];
        Debug.LogWarning(transform.name + ": Load EnemyInfoSO", gameObject);
    }

    protected virtual void LoadRigidBody()
    {
        if (enemyRb != null) return;

        enemyRb = GetComponent<Rigidbody2D>();
        Debug.LogWarning(transform.name + ": Load Rigidbody2D", gameObject);
    }
}
