using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private enum MovementState
    {
        Idle,
        Run,
        Hit,
    }

    private float _directionX;
    private float _lastTime;
    private bool _isHit = false;
    private Rigidbody2D _enemyRb;
    private Animator _enemyAnim;
    private SpriteRenderer _enemyRd;
    private Collider2D _enemyCollider;

    void Awake()
    {
        _directionX = 1;
        _enemyRb = GetComponent<Rigidbody2D>();
        _enemyAnim = GetComponent<Animator>();
        _enemyRd = GetComponent<SpriteRenderer>();
        _enemyCollider = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_isHit)
            return;

        if (_lastTime > 2f)
        {
            _lastTime = 0;
            _directionX = -_directionX;
        }
        _lastTime += Time.deltaTime;
        _enemyRb.velocity = new Vector2(_directionX, _enemyRb.velocity.y);
    }

    private void LateUpdate()
    {
        ChangeStateAnimation();
    }

    private void ChangeStateAnimation()
    {
        MovementState state;

        if (_directionX > 0f)
        {
            state = MovementState.Run;
            _enemyRd.flipX = false;
        }
        else if (_directionX < 0f)
        {
            state = MovementState.Run;
            _enemyRd.flipX = true;
        }
        else
            state = MovementState.Idle;

        _enemyAnim.SetInteger("state", (int)state);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isHit = true;
            _enemyRb.bodyType = RigidbodyType2D.Static;
            _enemyAnim.SetInteger("state", 2);
            StartCoroutine("Destroy");
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
