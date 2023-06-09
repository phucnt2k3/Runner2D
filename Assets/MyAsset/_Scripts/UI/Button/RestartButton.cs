using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : BaseButton
{
    protected override void OnClick()
    {
        GameManager.Instance.ShowPopUpStartGame();
    }
}