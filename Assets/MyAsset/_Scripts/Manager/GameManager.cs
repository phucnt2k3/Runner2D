using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MineBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;
    [SerializeField] private Transform _player;
    public Transform Player => _player;

    [SerializeField] private int _currentLevel = 0;
    public int CurrentLevel => _currentLevel;

    [SerializeField] private Transform _gamePlayUI;
    [SerializeField] private Transform _gameOverUI;
    [SerializeField] private Transform _gameStartUI;

    private void Awake()
    {
        if (GameManager.Instance != null) Debug.LogError(transform.name + ": invalid 2 instance", gameObject);
        instance = this;
        _gamePlayUI.gameObject.SetActive(false);
        _gameOverUI.gameObject.SetActive(false);
        _gameStartUI.gameObject.SetActive(false);
        _player.gameObject.SetActive(false);
    }

    private void Start()
    {
        ShowPopUpStartGame();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayer();
        LoadGamePlayUI();
        LoadGameOverUI();
        LoadGameStartUI();
    }

    protected virtual void LoadPlayer()
    {
        if (_player != null) return;

        _player = GameObject.Find("Player").transform;
        Debug.LogWarning(transform.name + ": Load Player", gameObject);
    }

    protected virtual void LoadGamePlayUI()
    {
        if (_gamePlayUI != null) return;

        _gamePlayUI = GameObject.Find("GamePlayUI").transform;
        Debug.LogWarning(transform.name + ": Load GamePlayUI", gameObject);
    }

    protected virtual void LoadGameOverUI()
    {
        if (_gameOverUI != null) return;

        _gameOverUI = GameObject.Find("GameOverUI").transform;
        Debug.LogWarning(transform.name + ": Load GameOverUI", gameObject);
    }

    protected virtual void LoadGameStartUI()
    {
        if (_gameStartUI != null) return;

        _gameStartUI = GameObject.Find("GameStartUI").transform;
        Debug.LogWarning(transform.name + ": Load GameStartUI", gameObject);
    }

    private void OnNextLevel()
    {
        PrePairMap();

        _player.gameObject.SetActive(true);
        _player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        _player.transform.position = new Vector2(2.5f, 2.5f);
        
        _currentLevel++;
    }

    protected virtual void PrePairMap()
    {
        FruitSpawner.Instance.DespawnAll();
        RoomSpawner.Instance.DespawnAll();
        TileSpawner.Instance.DespawnAll();

        MapGenerator.Instance.RoomGenerator.GenerateLevel(_currentLevel);

        int row = MapGenerator.Instance.RoomGenerator.Row;
        int col = MapGenerator.Instance.RoomGenerator.Col;
        MapGenerator.Instance.BoundaryGenerator.GenerateBoundaries(row * 8, col * 12);
    }

    public void OnWinGame()
    {
        OnNextLevel();
    }

    public void OnLoseGame()
    {
        _currentLevel = 0;
        _player.gameObject.SetActive(false);
        _gamePlayUI.gameObject.SetActive(false);
        _gameOverUI.gameObject.SetActive(true);
    }

    public void ShowPopUpStartGame()
    {
        _gameOverUI.gameObject.SetActive(false);
        _gameStartUI.gameObject.SetActive(true);
    }

    public void StartGame()
    {
        OnNextLevel();
        _gamePlayUI.gameObject.SetActive(true);
        _gameStartUI.gameObject.SetActive(false);
    }
}

public enum GameState
{
    OnWinGame,
    OnLoseGame,
}
