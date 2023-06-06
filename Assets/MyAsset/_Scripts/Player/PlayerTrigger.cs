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
        if (other.gameObject.CompareTag("Enemy"))
            playerCtrl.PlayerJump.JumpSingle();

        Vector3 relativeVelocity = other.relativeVelocity;
        // collison came from below -> jump
        if (other.gameObject.CompareTag("Terrain") && relativeVelocity.y > 0)
            playerCtrl.PlayerJump.SetJumpCount(0);
    }
}
