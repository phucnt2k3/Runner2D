using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundaryGenerator : MonoBehaviour 
{
    [SerializeField] private RoomInfo _roomInfo;
    public GameObject boundaryPoint;

    public void Generate(int row, int col, string parentDir)
    {
        for (int i = 0; i < row * _roomInfo.rows; ++i)
        {
            GenerateAndSetParent(-0.5f, 0.5f + i, parentDir);

            GenerateAndSetParent(-0.5f + col * _roomInfo.cols + 1, 0.5f + i, parentDir);
        }

        for (int i = 0; i < col * _roomInfo.cols + 2; ++i)
        {
            GenerateAndSetParent(-0.5f + i, -0.5f, parentDir);

            GenerateAndSetParent(-0.5f + i, -0.5f + row * _roomInfo.rows + 1, parentDir);
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
