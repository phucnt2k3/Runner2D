using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectPlayer : DetectTarget
{
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayer();
    }

    protected virtual void LoadPlayer()
    {
        if (target != null) return;

        target = GameObject.Find("Player").transform;
        Debug.LogWarning(transform.name + ": Load Player", gameObject);
    }
}
