using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemsCollector : MonoBehaviour
{
    private Animator _playerAnim;
    private int _score = 0;

    public int GetScore()
    {
        return _score;
    }

    // Start is called before the first frame update
    void Start()
    {
        _playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update() { }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Item"))
        {
            Destroy(other.gameObject);
            _score++;
            GameObject
                .Find("CountCherryText")
                .GetComponent<TextMeshProUGUI>()
                .SetText("Fruits: " + _score);
        } 
    }
}
