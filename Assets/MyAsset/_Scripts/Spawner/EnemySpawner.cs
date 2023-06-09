using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    [SerializeField] protected static EnemySpawner instance;
    public static EnemySpawner Instance => instance;

    protected virtual void Awake()
    {
        if (EnemySpawner.Instance != null) Debug.LogError(transform.name + ": invalid 2 instance", gameObject);
        EnemySpawner.instance = this;
    }
}
