using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCtrl : ObjCtrl
{
    [Header("Fruit Ctrl")]
    [SerializeField] private FruitDespawn fruitDespawn;
    public FruitDespawn FruitDespawn => fruitDespawn;

    protected override void LoadComponents()
    {

        base.LoadComponents();
        LoadFruitDespawn();
    }

    protected virtual void LoadFruitDespawn()
    {

        if (this.fruitDespawn != null) return;

        this.fruitDespawn = transform.GetComponentInChildren<FruitDespawn>();
        Debug.LogWarning(transform.name + ": Load Fruit Despawn", gameObject);
    }
}
