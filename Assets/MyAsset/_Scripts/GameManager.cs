using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int currentLevel = 1;
    private GameObject _player;
    private MapGenerator _mapGenerator;
    public GameObject rotateLevel;

    [SerializeField]
    private GameObject _gamePlayUI;

    [SerializeField]
    private GameObject _gameOverUI;

    [SerializeField]
    private GameObject _gameStartUI;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        _player.SetActive(false);
        StartGame();
    }

    public void NextLevel()
    {
        if (currentLevel > 1)
            Destroy(GameObject.Find("Level " + (currentLevel - 1)));

        GameObject newLevel = Instantiate(rotateLevel, new Vector2(0, 0), Quaternion.identity);
        newLevel.name = "Level " + currentLevel;

        _mapGenerator = GameObject.Find(newLevel.name + "/MapManager").GetComponent<MapGenerator>();
        _mapGenerator.GenerateLevel(currentLevel, newLevel.name + "ParentObject");
        
        _player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        _player.transform.position = new Vector2(2.5f, 2.5f);
        GameObject
            .Find("CurrentLevel")
            .GetComponent<TextMeshProUGUI>()
            .SetText("Level: " + currentLevel);
        currentLevel++;
    }

    public void GameOver()
    {
        Destroy(GameObject.Find("Level " + (currentLevel - 1)));
        _gamePlayUI.SetActive(false);
        _gameOverUI.SetActive(true);
    }

    public void StartGame()
    {
        _player.SetActive(false);
        _gamePlayUI.SetActive(false);
        _gameOverUI.SetActive(false);
        _gameStartUI.SetActive(true);
    }

    public void PlayInGame()
    {
        _player.SetActive(true);
        _player.GetComponent<PlayerLife>().SetLives(3);
        currentLevel = 1;
        _gamePlayUI.SetActive(true);
        _gameStartUI.SetActive(false);
        NextLevel();
    }
}
