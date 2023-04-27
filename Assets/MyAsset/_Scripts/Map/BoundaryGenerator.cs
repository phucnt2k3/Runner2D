using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryGenerator : MonoBehaviour
{
    public GameObject boundaryPoint;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    void Update() { }

    public void Generate(int row, int col, string parentDir)
    {
        for (int i = 0; i < row * 8; ++i)
        {
            GenerateAndSetParent(-0.5f, 0.5f + i, parentDir);

            GenerateAndSetParent(-0.5f + col * 12 + 1, 0.5f + i, parentDir);
        }

        for (int i = 0; i < col * 12 + 2; ++i)
        {
            GenerateAndSetParent(-0.5f + i, -0.5f, parentDir);

            GenerateAndSetParent(-0.5f + i, -0.5f + row * 8 + 1, parentDir);
        }
    }

    private void GenerateAndSetParent(float xPos, float yPos, string parentDir)
    {
        GameObject myObject = Instantiate(
            boundaryPoint,
            new Vector2(xPos, yPos),
            boundaryPoint.transform.rotation
        );
        myObject.transform.parent = GameObject.Find(parentDir).transform;
    }
}
