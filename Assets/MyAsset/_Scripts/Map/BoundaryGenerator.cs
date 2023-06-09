using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryGenerator : MineBehaviour 
{
    public virtual void GenerateBoundaries(int row, int col)
    {
        for (int i = 0; i < row; ++i)
        {
            Vector3 spawnPos = new Vector3(0f, 1f + i, 0f);
            TileSpawner.Instance.Spawn(TileSpawner.boundaryName, spawnPos, Quaternion.identity);

            spawnPos = new Vector3(1f + col, 1f + i, 0);
            TileSpawner.Instance.Spawn(TileSpawner.boundaryName, spawnPos, Quaternion.identity);
        }

        for (int i = 0; i < col + 2; ++i)
        {
            Vector3 spawnPos = new Vector3(0f + i, 0f, 0);
            TileSpawner.Instance.Spawn(TileSpawner.boundaryName, spawnPos, Quaternion.identity);

            spawnPos = new Vector3(0f + i, 1f + row, 0);
            TileSpawner.Instance.Spawn(TileSpawner.boundaryName, spawnPos, Quaternion.identity);
        }
    }
}
