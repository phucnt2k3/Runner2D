using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryTileSpawn : ObjSpawn
{
    protected override void Spawn()
    {
        Vector3 spawnPos = transform.position;
        spawnPos.z = -1;
        TileSpawner.Instance.Spawn(TileSpawner.boundaryName, spawnPos, Quaternion.identity);
    }
}
