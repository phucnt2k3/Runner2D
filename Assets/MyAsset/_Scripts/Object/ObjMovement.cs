using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ObjMovement : MineBehaviour
{

    // Update is called once per frame
    private void Update()
    {
        GetMovementInfo();
    }

    protected abstract void GetMovementInfo();

    private void LateUpdate()
    {
        MakeMovement();
    }

    protected abstract void MakeMovement();
}
