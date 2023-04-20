using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    private Transform _playerTransform;
    private Vector3 _updatePosition;
    private PlayerController _playerController;

    void Awake()
    {
        _playerTransform = GameObject.Find("Player").transform;
        _playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        _updatePosition = new Vector3(
            _playerTransform.position.x,
            _playerTransform.position.y,
            transform.position.z
        );
    }

    private void LateUpdate()
    {
        transform.position = _updatePosition;
    }
}
