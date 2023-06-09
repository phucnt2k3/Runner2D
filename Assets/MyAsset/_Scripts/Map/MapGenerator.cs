using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class MapGenerator : MineBehaviour
{
    private static MapGenerator instance;
    public static MapGenerator Instance => instance;
    [Header("Map Generator")]
    [SerializeField] protected RoomGenerator roomGenerator;
    public RoomGenerator RoomGenerator => roomGenerator;
    [SerializeField] protected BoundaryGenerator boundaryGenerator;
    public BoundaryGenerator BoundaryGenerator => boundaryGenerator;

    private void Awake()
    {
        if (MapGenerator.Instance != null) Debug.LogError(transform.name + ": invalid 2 instance", gameObject);
        instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadRoomGenerator();
        LoadBoundaryGenerator();
    }

    protected virtual void LoadRoomGenerator()
    {
        if (roomGenerator != null) return;

        roomGenerator = GetComponentInChildren<RoomGenerator>();
        Debug.LogWarning(transform.name + ": Load RoomGenerator", gameObject);
    }

    protected virtual void LoadBoundaryGenerator()
    {
        if (boundaryGenerator != null) return;

        boundaryGenerator = GetComponentInChildren<BoundaryGenerator>();
        Debug.LogWarning(transform.name + ": Load BoundaryGenerator", gameObject);
    }
}


