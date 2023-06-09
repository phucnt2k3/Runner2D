using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FollowTarget : MineBehaviour
{
    [Header("Follow Target")]
    [SerializeField] protected Transform target;

    [SerializeField] protected float speed = 0.1f;

    private void FixedUpdate()
    {
        Following();
    }

    protected virtual void Following()
    {
        transform.position = Vector3.Lerp(
            transform.position,
            target.position,
            speed * Time.fixedDeltaTime
        );
    }
}
