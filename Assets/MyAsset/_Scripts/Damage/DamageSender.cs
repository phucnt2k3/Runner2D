using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageSender : MineBehaviour
{

    [Header("Damage Sender")]
    [SerializeField] protected int damage = 1;

    public virtual void Send(Transform obj)
    {
        var receiver = obj.GetComponentInChildren<DamageReceiver>();
        if (receiver == null) return;

        this.Send(receiver);
    }

    public virtual void Send(DamageReceiver receiver)
    {
        receiver.Remove(this.damage);
    }

    protected virtual void OnDestroy()
    {
        // for override
    }
}
