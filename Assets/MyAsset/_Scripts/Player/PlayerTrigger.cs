using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTrigger : PlayerAbstract
{
    protected override void LoadPlayerCtrl()
    {
        if (playerCtrl != null) return;

        playerCtrl = transform.GetComponent<PlayerCtrl>();
        Debug.LogWarning(transform.name + ": Load PlayerCtrl", gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Vector3 relativeVelocity = other.relativeVelocity;
        // collison came from below -> jump
        if (other.gameObject.CompareTag("Terrain") && relativeVelocity.y > 0)
            playerCtrl.PlayerJump.SetJumpCount(0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var fruiTouchable = other.gameObject.GetComponent<FruitTouchable>();
        if(fruiTouchable != null) playerCtrl.FruitCollector.SetCollectedFruits(1);

        if (!other.gameObject.CompareTag("Enemy")) return;

        playerCtrl.PlayerJump.JumpSingle();
        playerCtrl.DamageSender.Send(other.gameObject.transform);
    }
}
