using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitTouchable : ObjTouchable
{
    [Header("Fruit Touchable")]
    [SerializeField] FruitCtrl fruitCtrl;

    protected override void LoadComponents()
    {

        base.LoadComponents();
        LoadFruitCtrl();
    }

    protected virtual void LoadFruitCtrl()
    {

        if (fruitCtrl != null) return;

        fruitCtrl = transform.parent.GetComponent<FruitCtrl>();
        Debug.LogWarning(transform.name + ": Load FruitCtrl", gameObject);
    }

    protected override void OnTouch(Collider2D other)
    {
        fruitCtrl.FruitDespawn.Hit();
    }
}
