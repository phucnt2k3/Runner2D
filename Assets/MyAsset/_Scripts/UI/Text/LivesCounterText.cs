using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LivesCounterText : BaseText
{
    protected virtual void FixedUpdate()
    {
        this.UpdateHP();
    }

    protected virtual void UpdateHP()
    {
        PlayerCtrl playerCtrl = GameManager.Instance.Player.GetComponent<PlayerCtrl>();
        int hp = playerCtrl.DamageReceiver.CurrentHP;

        this.text.SetText("Lives: " + hp);
    }
}
