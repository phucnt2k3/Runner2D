using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class ObjTouchable : MineBehaviour
{
    [Header("Object Touchable")]
    [SerializeField] protected bool isTouched = false;
    [SerializeField] protected BoxCollider2D boxCollider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadBoxCollider();
    }

    protected virtual void LoadBoxCollider()
    {
        if (boxCollider != null) return;

        boxCollider = transform.GetComponent<BoxCollider2D>();
        boxCollider.isTrigger = true;
        Debug.LogWarning(transform.name + ": Load BoxCollider", gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        OnTouch(other);
    }

    protected abstract void OnTouch(Collider2D other);
}
