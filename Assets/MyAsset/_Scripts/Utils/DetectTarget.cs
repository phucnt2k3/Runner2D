using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectTarget : MineBehaviour
{
    [Header("Detect target")]
    [SerializeField] protected Transform target;
    [SerializeField] protected float radius = 5f;
    [SerializeField] protected bool isDetected = false;
    public bool IsDetected => isDetected;

    private void Update()
    {
        Detecting();
    }

    protected virtual void Detecting()
    {
        isDetected = Vector3.Distance(transform.position, target.position) <= radius;
    }
}
