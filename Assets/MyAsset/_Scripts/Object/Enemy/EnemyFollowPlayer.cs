using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : FollowPlayer
{

    protected override void Following()
    {
        transform.parent.position = Vector3.Lerp(transform.parent.position, target.position, speed * Time.fixedDeltaTime);
    }
}
