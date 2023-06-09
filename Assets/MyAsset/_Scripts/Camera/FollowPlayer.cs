using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : FollowTarget
{
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayer();
    }

    protected virtual void LoadPlayer()
    {
        if (this.target != null) return;

        this.target = GameObject.Find("Player").transform;
        Debug.LogWarning(transform.name + ": Load Player Transform", gameObject);
    }
}
