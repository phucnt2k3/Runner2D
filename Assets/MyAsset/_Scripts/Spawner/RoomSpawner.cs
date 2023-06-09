using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RoomSpawner : Spawner
{
    [Header("Room Spawner")]
    [SerializeField] protected static RoomSpawner instance;
    private int NUMBER_ROOM_TYPE = 6;
    public static RoomSpawner Instance => instance;

    protected virtual void Awake()
    {
        if (RoomSpawner.Instance != null) 
            Debug.LogError(transform.name + ": invalid 2 instance", gameObject);
        RoomSpawner.instance = this;
    }

    public virtual Transform SpawnRoom(int index, Vector3 position, Quaternion rotation)
    {
        if (index > prefabs.Count) return null;

        return Spawn(prefabs[index], position, rotation);
    }

    public virtual int RandomNotExitRoomIndex()
    {
        int index = Random.Range(0, NUMBER_ROOM_TYPE - 2);
        return index;
    }
}
