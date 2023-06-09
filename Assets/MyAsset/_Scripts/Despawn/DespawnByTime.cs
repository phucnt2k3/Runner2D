using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DespawnByTime : Despawn
{

    [Header("Despawn By Time")]
    [SerializeField] protected float delayTimer;
    [SerializeField] protected float delayLimit;

    protected virtual void OnEnable()
    {
        this.ResetTimer();
    }

    protected virtual void ResetTimer()
    {

        this.delayTimer = 0;
    }

    protected override bool CanDespawn()
    {

        this.delayTimer += Time.fixedDeltaTime;
        if (this.delayTimer > this.delayLimit) return true;

        return false;
    }

    protected override void OnDespawn()
    {
        // for override
    }
}
