using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamSender : DamageSender
{
    [Header("Enemy Damage Sender")]
    [SerializeField] protected EnemyCtrl enemyCtrl;

    protected override void LoadComponents()
    {

        base.LoadComponents();
        this.LoadEnemyCtrl();
    }

    protected virtual void LoadEnemyCtrl()
    {

        if (this.enemyCtrl != null) return;

        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.LogWarning(transform.name + " : Load EnemyCtrl", gameObject);
    }

    public override void Send(DamageReceiver receiver)
    {

        base.Send(receiver);
    }
}
