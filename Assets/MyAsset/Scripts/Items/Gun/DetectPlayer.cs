using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DetectPlayer : MonoBehaviour
{
    public float _rotationSpeed = 5f; // The speed at which the gun rotates
    public float detectionRadius = 5f; // The maximum distance the gun can detect the player
    public float bulletSpeed = 10f;
    private bool _playerInSight = false; // Whether the player is in range of the gun
    public GameObject bulletPrefab;
    private Transform _player; // A reference to the player's transform
    private float _lastTime;

    void Start()
    {
        _player = GameObject.Find("Player").GetComponent<RectTransform>().transform;
    }

    void Update()
    {
        // Check if the player is in range of the gun
        if (Vector2.Distance(transform.position, _player.position) <= detectionRadius)
            _playerInSight = true;
        else
            _playerInSight = false;

        // Rotate the gun towards the player
        if (_playerInSight)
        {
            Vector2 directionToPlayer = _player.position - transform.position;
            float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                Time.deltaTime * _rotationSpeed
            );

            if (_lastTime == 0)
            {
                ShootBullet();
                _lastTime = 0;
            }
        }
        _lastTime += Time.deltaTime;
        if (_lastTime > 1.0f)
            _lastTime = 0;
    }

    private void ShootBullet()
    {
        // Instantiate a bullet prefab
        Vector3 position = new Vector3(
            transform.position.x,
            transform.position.y,
            transform.position.z
        );
        GameObject bullet = Instantiate(bulletPrefab, position, transform.rotation);

        // Add a velocity to the bullet
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = transform.right * bulletSpeed;
        bulletRigidbody.gravityScale = 0f;
        bulletRigidbody.freezeRotation = true;
    }
}
