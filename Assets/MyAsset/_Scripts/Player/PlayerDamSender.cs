using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamSender : DamageSender
{

    [Header("Player Damage Sender")]
    [SerializeField] protected PlayerCtrl playerCtrl;

    protected override void LoadComponents()
    {

        base.LoadComponents();
        this.LoadPlayerCtrl();
    }

    protected virtual void LoadPlayerCtrl()
    {

        if (this.playerCtrl != null) return;

        this.playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
        Debug.LogWarning(transform.name + " : Load PlayerCtrl", gameObject);
    }

    public override void Send(DamageReceiver receiver)
    {

        base.Send(receiver);
    }
}
