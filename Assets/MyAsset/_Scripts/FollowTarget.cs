using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FollowTarget : MineBehaviour
{
    [Header("Follow Target")]
    [SerializeField] protected Transform _target;

    [SerializeField]
    private float speed = 0.1f;

    private void FixedUpdate()
    {
        Following();
    }

    protected virtual void Following()
    {
        transform.position = Vector3.Lerp(
            transform.position,
            _target.position,
            speed * Time.fixedDeltaTime
        );
    }
}
