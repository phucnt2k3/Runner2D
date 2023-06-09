using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectPlayer : MineBehaviour
{
    [SerializeField] protected Transform player;
    [SerializeField] protected float radius = 10f;
    [SerializeField] protected EnemyCtrl enemyCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayer();
        LoadEnemyCtrl();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (enemyCtrl != null) return;

        enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.LogWarning(transform.name + ": Load EnemyCtrl", gameObject);
    }

    protected virtual void LoadPlayer()
    {
        if (player != null) return;

        player = GameObject.Find("Player").transform;
        Debug.LogWarning(transform.name + ": Load Player", gameObject);
    }

    private void Update()
    {
        Detecting();
    }

    private void Detecting()
    {
        float distance = Vector3.Distance(transform.parent.position, player.position);
        enemyCtrl.EnemyMove.enabled = (distance <= radius);
    }
}
