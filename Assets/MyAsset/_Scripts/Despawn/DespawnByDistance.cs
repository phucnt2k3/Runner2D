using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DespawnByDistance : Despawn
{
    [Header("Despawn By Distance")]
    [SerializeField] protected Transform target;
    [SerializeField] protected float disLimit = 70f;
    [SerializeField] protected float distance = 0f;

    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(target.position, transform.parent.position);
        return this.distance > this.disLimit;
    }

    protected override void OnDespawn()
    {
        throw new System.NotImplementedException();
    }
}

