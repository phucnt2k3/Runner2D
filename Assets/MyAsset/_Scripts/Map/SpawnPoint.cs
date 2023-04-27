using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    public List<Sprite> sprites;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        GenerateSprite();
    }

    private void GenerateSprite()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, -1f);
        int sizeList = sprites.Count;
        int index = Random.Range(0, sizeList);
        if (sprites[index] != null)
            _spriteRenderer.sprite = sprites[index];
        else
            Destroy(gameObject);
    }
}
