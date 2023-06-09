using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamReceiver : DamageReceiver
{
    [Header("Enemy Damage Receiver")]
    [SerializeField] protected PlayerCtrl playerCtrl;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerCtrl();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (playerCtrl != null) return;

        playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
        Debug.LogWarning(transform.name + ": Load PlayerCtrl", gameObject);
    }

    public override void Reborn()
    {

        this.maxHP = playerCtrl.PlayerInfo.maxHP;
        base.Reborn();
    }

    protected override void OnDead()
    {
        var spawnPos = transform.position;
        spawnPos.z = -1;
        transform.parent.gameObject.SetActive(false);
        FXSpawner.Instance.Spawn(FXSpawner.fxDespawnName, spawnPos, Quaternion.identity);
        Invoke("WaitFXOnLoseGame", 1f);
    }

    private void WaitFXOnLoseGame()
    {
        GameManager.Instance.OnLoseGame();
    }
}
