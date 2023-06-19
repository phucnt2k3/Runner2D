using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButton : BaseButton
{
    protected override void OnClick()
    {
        InputManager.Instance.Jump();
    }
}