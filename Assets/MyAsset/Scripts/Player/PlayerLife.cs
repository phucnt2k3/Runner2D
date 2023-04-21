using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerLife : MonoBehaviour
{
    private int _lives = 3;
    private Rigidbody2D _playerRb;
    private Animator _playerAnim;
    private GameManager _gameManager;

    void Awake()
    {
        _playerAnim = GetComponent<Animator>();
        _playerRb = GetComponent<Rigidbody2D>();
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            Die();
        }
    }

    private void Die()
    {
        _lives--;
        GameObject.Find("LivesCounter").GetComponent<TextMeshProUGUI>().SetText("Lives: " + _lives);
        _playerRb.bodyType = RigidbodyType2D.Static;
        _playerAnim.SetTrigger("death");
    }

    public void RestartLevel() // call in anim event
    {
        if (_lives == 0)
        {
            int highestScore = PlayerPrefs.GetInt("Score");
            ItemsCollector itemsCollector = GetComponent<ItemsCollector>();
            int currentScore = itemsCollector.GetScore();
            if (highestScore < currentScore)
            {
                PlayerPrefs.SetInt("Score", currentScore);
                PlayerPrefs.Save();
            }

            _gameManager.GameOver();
            return;
        }

        transform.position = new Vector2(2.5f, 2.5f);
        _playerAnim.SetInteger("state", 0);
        _playerRb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            ContactPoint2D[] contacts = other.contacts;
            foreach (ContactPoint2D contact in contacts)
            {
                if (Mathf.Abs(contact.normal.y) <= Mathf.Abs(contact.normal.x))
                {
                    Die();
                    break;
                }
            }
        }
    }
}
