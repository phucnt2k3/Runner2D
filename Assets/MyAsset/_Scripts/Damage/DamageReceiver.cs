using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DamageReceiver : MineBehaviour
{

    [Header("Damage Receiver")]
    [SerializeField] protected int currentHP;
    public int CurrentHP => currentHP;
    [SerializeField] protected int maxHP;
    [SerializeField] protected bool isDead = false;

    protected virtual void OnEnable()
    {
        this.Reborn();
    }

    public virtual void Reborn() { this.currentHP = this.maxHP; this.isDead = false; }

    public void Add(int add)
    {

        if (this.isDead) return;

        this.currentHP += add;
        if (this.currentHP > maxHP) { this.currentHP = maxHP; }
    }

    public void Remove(int remove)
    {

        if (this.isDead) return;

        this.currentHP -= remove;
        if (this.currentHP < 0) { this.currentHP = 0; }
        this.CheckIsDead();
    }

    protected virtual void CheckIsDead()
    {

        if (!this.IsDead()) return;

        this.isDead = true;
        this.OnDead();
    }

    protected virtual bool IsDead() { return this.currentHP <= 0; }

    protected abstract void OnDead();
}
