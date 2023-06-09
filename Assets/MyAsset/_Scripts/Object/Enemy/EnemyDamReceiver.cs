using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamReceiver : DamageReceiver
{
    [Header("Enemy Damage Receiver")]
    [SerializeField] protected EnemyCtrl enemyCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemyCtrl();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (enemyCtrl != null) return;

        enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.LogWarning(transform.name + ": Load EnemyCtrl", gameObject);
    }

    public override void Reborn()
    {

        this.maxHP = enemyCtrl.EnemyInfo.maxHP;
        base.Reborn();
    }

    protected override void OnDead()
    {

        enemyCtrl.Despawn.DespawnObject();
    }
}
