using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : Spawner
{
    [SerializeField] protected static FruitSpawner instance;
    public static FruitSpawner Instance => instance;
    public static string apple = "Apple";

    protected virtual void Awake()
    {
        if (FruitSpawner.Instance != null) Debug.LogError(transform.name + ": invalid 2 instance", gameObject);
        FruitSpawner.instance = this;
    }
}
