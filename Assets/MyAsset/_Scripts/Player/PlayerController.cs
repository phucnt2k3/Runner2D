using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private PlayerInfo _playerInfo;
    public float directionX;
    private int _countJump = 0;

    [SerializeField]
    private LayerMask jumpableGround;
    private Rigidbody2D _playerRb;

    [SerializeField]
    private Joystick _joystick;

    private void Awake()
    {
        _playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        // moving left right
        directionX = Input.GetAxis("Horizontal");
        // if user pressed jump button
        if (Input.GetButtonDown("Jump"))
            Jump();
#else
        directionX = _joystick.Horizontal;
#endif
        if (_playerRb.bodyType != RigidbodyType2D.Static)
        {
            _playerRb.velocity = new Vector2(
                directionX * _playerInfo.moveSpeed,
                _playerRb.velocity.y
            );
        }
    }

    public void Jump() // call in jump button event
    {
        if (_countJump > 1)
            return;
        _countJump++;
        if (_playerRb.bodyType != RigidbodyType2D.Static)
        {
            _playerRb.velocity = new Vector2(_playerRb.velocity.x, _playerInfo.jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _playerRb.velocity = new Vector2(_playerRb.velocity.x, _playerInfo.jumpForce);
        }

        Vector3 relativeVelocity = other.relativeVelocity;

        // collison came from below -> jump
        if (other.gameObject.CompareTag("Terrain") && relativeVelocity.y > 0)
        {
            _countJump = 0;
        }
    }
}
