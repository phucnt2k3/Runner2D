using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MineBehaviour
{
    private static InputManager instance;
    public static InputManager Instance => instance;
    [SerializeField] private float _directionX = 0f;
    public float DirectionX => _directionX;
    [SerializeField] private float _directionY = 0f;
    public float DirectionY => _directionY;
    [SerializeField] private bool _isJump = false;
    public bool IsJump => _isJump;
    public void Jump() => _isJump = true;

    private void Awake()
    {
        if(InputManager.Instance != null) Debug.LogError(transform.name + ": invalid 2 instance", gameObject);
        instance = this;
    }

    private void Update()
    {
        GetDirection();
        CheckJump();
    }

    protected virtual void CheckJump()
    {
        _isJump = Input.GetButtonDown("Jump");
    }

    protected virtual void GetDirection()
    {
        _directionX = Input.GetAxis("Horizontal");
        _directionY = Input.GetAxis("Vertical");
    }
}
