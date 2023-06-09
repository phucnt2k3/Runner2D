using UnityEngine;

public class FruitDespawn : Despawn
{
    [SerializeField] private bool _isHit = false;
    public void Hit() => _isHit = true;

    protected virtual void OnEnable()
    {
        _isHit = false;
    }

    public override void DespawnObject()
    {
        FruitSpawner.Instance.Despawn(transform.parent);
    }

    protected override bool CanDespawn()
    {
        return _isHit;
    }

    protected override void OnDespawn()
    {
        FXSpawner.Instance.Spawn(FXSpawner.fxScoreCollectName, transform.position, Quaternion.identity);   
    }
}
