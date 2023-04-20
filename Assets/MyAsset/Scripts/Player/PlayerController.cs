using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float directionX;
    private float _moveSpeed = 7.0f;
    private float _jumpForce = 10.0f;
    private int _countJump = 0;

    [SerializeField]
    private LayerMask jumpableGround;
    private Rigidbody2D _playerRb;
    private Collider2D _playerCollider;
    public Joystick joystick;

    private void Awake()
    {
        _playerRb = GetComponent<Rigidbody2D>();
        _playerCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateCountJump();

#if UNITY_EDITOR
        // moving left right
        directionX = Input.GetAxis("Horizontal");
        // if user pressed jump button
        if (Input.GetButtonDown("Jump"))
            Jump();
#else
        directionX = joystick.Horizontal;
#endif
        _playerRb.velocity = new Vector2(directionX * _moveSpeed, _playerRb.velocity.y);
    }

    public void Jump()
    {
        if (_countJump > 1)
            return;
        _countJump++;
        _playerRb.velocity = new Vector2(_playerRb.velocity.x, _jumpForce);
    }

    private void UpdateCountJump()
    {
        bool isGrounded = Physics2D.BoxCast(
            _playerCollider.bounds.center,
            _playerCollider.bounds.size,
            0f,
            Vector2.down,
            .1f,
            jumpableGround
        );
        // check if on ground
        if (isGrounded)
            _countJump = 0;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            _playerRb.velocity = new Vector2(_playerRb.velocity.x, _jumpForce);
        }
    }
}
