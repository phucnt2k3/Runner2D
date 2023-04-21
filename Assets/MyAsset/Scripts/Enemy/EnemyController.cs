using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float directionX;
    private float _lastTime;
    private bool _isHit = false;
    private Rigidbody2D _enemyRb;
    private Collider2D _enemyCollider;

    void Awake()
    {
        directionX = 1;
        _enemyRb = GetComponent<Rigidbody2D>();
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
            directionX = -directionX;
        }
        _lastTime += Time.deltaTime;
        _enemyRb.velocity = new Vector2(directionX, _enemyRb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _isHit = true;
            _enemyRb.bodyType = RigidbodyType2D.Static;
            StartCoroutine("Destroy");
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }
}
