using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCounterText : BaseText
{
    protected virtual void FixedUpdate()
    {
        this.UpdateFruitCounterText();
    }

    protected virtual void UpdateFruitCounterText()
    {
        PlayerCtrl playerCtrl = GameManager.Instance.Player.GetComponent<PlayerCtrl>();
        int fruits = playerCtrl.FruitCollector.CollectedFruits;

        this.text.SetText("Fruits: " + fruits);
    }
}
