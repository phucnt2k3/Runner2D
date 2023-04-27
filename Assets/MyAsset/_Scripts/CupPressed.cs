using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CupPressed : MonoBehaviour
{
    private Animator _cupAnim;
    private bool _isFinished;
    private GameManager _gameManager;

    // Start is called before the first frame update
    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _isFinished = false;
        _cupAnim = GetComponent<Animator>();
        _cupAnim.SetTrigger("Begin");
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") && !_isFinished)
        {
            _cupAnim.SetTrigger("Win");
            Invoke("RestartLevel", 1.0f);
        }
    }

    private void RestartLevel()
    {
        Destroy(GameObject.Find("Level " + _gameManager.currentLevel));
        _gameManager.NextLevel();
    }
}
