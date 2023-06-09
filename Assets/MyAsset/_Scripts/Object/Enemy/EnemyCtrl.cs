using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCtrl : ObjCtrl
{
    [Header("Enemy Ctrl")]
    [SerializeField] private EnemyConfigSO enemyInfo;
    public EnemyConfigSO EnemyInfo => enemyInfo;
    [SerializeField] private Rigidbody2D enemyRb;
    public Rigidbody2D EnemyRb => enemyRb;
    [SerializeField] private EnemyMove enemyMove;
    public EnemyMove EnemyMove => enemyMove;
    [SerializeField] private Despawn enemyDespawn;
    public Despawn Despawn => enemyDespawn;
    [SerializeField] private DamageSender enemyDamageSender;
    public DamageSender DamageSender => enemyDamageSender;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadRigidBody();
        LoadEnemyConfig();
        LoadEnemyMove();
        LoadEnemyDespawn();
        LoadEnemyDamageSender();
    }

    protected virtual void LoadEnemyDamageSender()
    {
        if (enemyDamageSender != null) return;

        enemyDamageSender = transform.GetComponentInChildren<DamageSender>();
        Debug.LogWarning(transform.name + ": Load Enemy DamageSender", gameObject);
    }

    protected virtual void LoadEnemyDespawn()
    {
        if (enemyDespawn != null) return;

        enemyDespawn = transform.GetComponentInChildren<Despawn>();
        Debug.LogWarning(transform.name + ": Load Enemy Despawn", gameObject);
    }

    protected virtual void LoadEnemyMove()
    {
        if (enemyMove != null) return;

        enemyMove = transform.GetComponentInChildren<EnemyMove>();
        Debug.LogWarning(transform.name + ": Load EnemyMove", gameObject);
    }

    protected virtual void LoadEnemyConfig()
    {
        if (enemyInfo != null) return;

        var objs = Resources.LoadAll("_Config/Enemy", typeof(EnemyConfigSO));
        if (objs.Length > 1)
            Debug.LogError(transform.name + ": Resources LoadAll 1 more EnemyConfigSO", gameObject);

        enemyInfo = (EnemyConfigSO) objs[0];
        Debug.LogWarning(transform.name + ": Load EnemyConfigSO", gameObject);
    }

    protected virtual void LoadRigidBody()
    {
        if (enemyRb != null) return;

        enemyRb = GetComponent<Rigidbody2D>();
        Debug.LogWarning(transform.name + ": Load Rigidbody2D", gameObject);
    }
}
