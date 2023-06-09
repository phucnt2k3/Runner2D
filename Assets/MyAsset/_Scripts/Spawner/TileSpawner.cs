using UnityEngine;

public class TileSpawner : Spawner
{
    [SerializeField] protected static TileSpawner instance;
    public static TileSpawner Instance => instance;
    public static string boundaryName = "Boundary";
    public static string terrainName = "Terrain";

    protected virtual void Awake()
    {
        if (TileSpawner.Instance != null) Debug.LogError(transform.name + ": invalid 2 instance", gameObject);
        TileSpawner.instance = this;
    }

    
}
