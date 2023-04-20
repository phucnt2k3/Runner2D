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

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("Player");
        NextLevel();
    }

    // Update is called once per frame
    void Update() { }

    public void NextLevel()
    {
        if (currentLevel > 1)
            Destroy(GameObject.Find("Level " + (currentLevel - 1)));

        GameObject newLevel = Instantiate(rotateLevel, new Vector2(0, 0), Quaternion.identity);
        newLevel.name = "Level " + currentLevel;

        _mapGenerator = GameObject.Find(newLevel.name + "/MapManager").GetComponent<MapGenerator>();
        _mapGenerator.GenerateLevel(currentLevel, newLevel.name + "ParentObject");

        _player.transform.position = new Vector2(2.5f, 2.5f);
        GameObject
            .Find("CurrentLevel")
            .GetComponent<TextMeshProUGUI>()
            .SetText("Level: " + currentLevel);
        currentLevel++;
    }

    public void GameOver()
    {   
        SceneManager.LoadScene(1);
    }
}
