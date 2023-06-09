using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjSpawn : MineBehaviour
{
    private void OnEnable()
    {
        Spawn();
    }

    protected abstract void Spawn();
}
