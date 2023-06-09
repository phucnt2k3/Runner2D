using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainTileSpawn : ObjSpawn
{
    protected override void Spawn()
    {
        Vector3 spawnPos = transform.position;
        spawnPos.z = -1;
        TileSpawner.Instance.Spawn(TileSpawner.terrainName, spawnPos, Quaternion.identity);
    }
}