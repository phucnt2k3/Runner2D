using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjCtrl : MineBehaviour
{
    [Header("Object Ctrl")]
    [SerializeField] protected Transform model;
    public Transform Model => model;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadModel();
    }

    private void LoadModel()
    {
        if (model != null) return;

        model = transform.Find("Model").GetComponent<Transform>();
        Debug.LogWarning(transform.name + ": Load Model", gameObject);
    }
}
