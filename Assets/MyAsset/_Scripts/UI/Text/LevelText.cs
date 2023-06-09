using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelText : BaseText
{
    protected virtual void FixedUpdate()
    {
        this.UpdateLevelText();
    }

    protected virtual void UpdateLevelText()
    {
        int level = GameManager.Instance.CurrentLevel;
        this.text.SetText("Level: " + level);
    }
}
