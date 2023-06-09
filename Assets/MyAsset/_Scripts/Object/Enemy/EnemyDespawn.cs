using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDespawn : Despawn
{
    private bool isDespawn = false;
    public void IsDespawn() => isDespawn = true;

    private void OnEnable()
    {
        isDespawn = false;
    }

    public override void DespawnObject()
    {
        EnemySpawner.Instance.Despawn(transform.parent);
        OnDespawn();
    }

    protected override bool CanDespawn()
    {
        return isDespawn;
    }

    protected override void OnDespawn()
    {
        Vector3 spawnPos = transform.position;
        spawnPos.z = -1;
        FXSpawner.Instance.Spawn(FXSpawner.fxDespawnName, spawnPos, Quaternion.identity);
    }
}
