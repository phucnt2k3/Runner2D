using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MineBehaviour
{
    [SerializeField] protected EnemyCtrl enemyCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemyCtrl();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (enemyCtrl != null) return;

        enemyCtrl = GetComponent<EnemyCtrl>();
        Debug.LogWarning(transform.name + ": Load EnemyCtrl", gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        enemyCtrl.DamageSender.Send(collision.gameObject.transform);
    }
}
