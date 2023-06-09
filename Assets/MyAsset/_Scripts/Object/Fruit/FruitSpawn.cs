using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawn : ObjSpawn
{
    protected override void Spawn()
    {
        var fruit = FruitSpawner.Instance.RandomPrefab();
        FruitSpawner.Instance.Spawn(fruit, transform.position, Quaternion.identity);
    }
}
