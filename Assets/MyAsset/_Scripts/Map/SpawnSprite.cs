using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSprite : MonoBehaviour
{
    public List<GameObject> prefabsSprites;

    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        int sizeList = prefabsSprites.Count;
        int index = Random.Range(0, sizeList);
        Vector3 position = new Vector3(
            gameObject.transform.position.x,
            gameObject.transform.position.y,
            -1f
        );
        Destroy(gameObject);
        if (index != sizeList - 1)
        {
            GameObject myObject = Instantiate(prefabsSprites[index], position, Quaternion.identity);
            string levelName = "Level " + (gameManager.currentLevel - 1);
            myObject.transform.parent = GameObject.Find(levelName + "/ParentObject").transform;
        }
    }

    // Update is called once per frame
    void Update() { }
}
