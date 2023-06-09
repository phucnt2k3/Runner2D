using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : MineBehaviour
{
    [Header("Spawner")]
    [SerializeField] protected Transform holder;
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;
    [SerializeField] protected int spawnedCount = 0;

    protected override void LoadComponents()
    {

        this.LoadPrefabs();
        this.LoadHolder();
    }

    protected virtual void LoadHolder()
    {

        if (this.holder != null) return;

        this.holder = transform.Find("Holder");
        Debug.LogWarning(transform.name + " : Load Holder", gameObject);
    }

    protected virtual void LoadPrefabs()
    {

        if (prefabs.Count > 0) return;

        Transform prefabObjs = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObjs)
        {
            prefabs.Add(prefab);
        }

        this.HidePrefabs();

        Debug.LogWarning(transform.name + ": LoadPrefabs", gameObject);
    }

    protected virtual void HidePrefabs()
    {

        foreach (Transform prefab in prefabs)
            prefab.gameObject.SetActive(false);
    }

    public virtual Transform Spawn(string prefabName, Vector3 spawnPos, Quaternion spawnRot)
    {

        Transform prefab = this.GetPrefabByName(prefabName);
        if (prefab == null)
        {
            Debug.LogWarning("Prefab not found !!! - " + prefabName);
            return null;
        }

        return Spawn(prefab, spawnPos, spawnRot);
    }

    public virtual Transform Spawn(Transform prefab, Vector3 spawnPos, Quaternion spawnRot)
    {

        Transform newPrefab = GetObjectFromPool(prefab);
        newPrefab.SetPositionAndRotation(spawnPos, spawnRot);
        newPrefab.gameObject.SetActive(true);

        newPrefab.parent = this.holder;
        this.spawnedCount++;
        return newPrefab;
    }

    public virtual Transform RandomPrefab()
    {

        int randIndex = Random.Range(0, this.prefabs.Count);
        return this.prefabs[randIndex];
    }

    protected virtual Transform GetObjectFromPool(Transform prefab)
    {

        foreach (Transform poolObj in poolObjs)
        {
            if (poolObj.name == prefab.name)
            {
                poolObjs.Remove(poolObj);
                return poolObj;
            }
        }

        Transform newPrefab = Instantiate(prefab);
        newPrefab.name = prefab.name;
        return newPrefab;
    }

    public virtual void Despawn(Transform obj)
    {

        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
        this.spawnedCount--;
    }

    public virtual void DespawnAll()
    {
        var objs = holder.GetComponentInChildren<Transform>();
        foreach(Transform obj in objs)
            if(obj.gameObject.activeSelf)
                Despawn(obj);
    }

    protected virtual Transform GetPrefabByName(string prefabName)
    {

        foreach (Transform prefab in prefabs)
            if (prefab.name == prefabName)
                return prefab;

        return null;
    }

    public virtual int CountSpawned() => this.spawnedCount;
}
