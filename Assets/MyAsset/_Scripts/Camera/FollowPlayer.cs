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
        if (this._target != null) return;

        this._target = GameManager.Instance.Player;
        Debug.LogWarning(transform.name + ": Load Player Transform", gameObject);
    }
}
