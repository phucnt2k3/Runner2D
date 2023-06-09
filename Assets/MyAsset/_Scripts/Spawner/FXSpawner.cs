using UnityEngine;

public class FXSpawner : Spawner
{
    [SerializeField] protected static FXSpawner instance;
    public static FXSpawner Instance => instance;
    public static string fxDespawnName = "FXDespawn";
    public static string fxScoreCollectName = "FXScoreCollect";

    protected virtual void Awake()
    {
        if (FXSpawner.Instance != null) Debug.LogError(transform.name + ": invalid 2 instance", gameObject);
        FXSpawner.instance = this;
    }

    
}
