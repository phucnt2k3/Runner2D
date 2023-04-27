using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public List<GameObject> prefabRooms;

    private int _col = 4;
    private int _row = 4;
    private float[,] _roomX;
    private float[,] _roomY;
    private int[,] _indexOfRoom;

    private bool[,] _visited;

    private BoundaryGenerator _boundaryGenerator;

    public void GenerateLevel(int level, string parentDir)
    {
        _boundaryGenerator = GameObject.Find("MapManager").GetComponent<BoundaryGenerator>();
        if (level < 3)
            _row = 2;
        else if (level < 5)
            _row = 3;
        else
            _row = 4;
        _col = _row;
        _boundaryGenerator.Generate(_row, _col, parentDir);
        Init();
        FindSolutionPathRooms(0, 0, true);
        GenerateRooms(parentDir);
    }

    private void Init()
    {
        _roomX = new float[_row, _col];
        _roomY = new float[_row, _col];
        _visited = new bool[_row, _col];
        _indexOfRoom = new int[_row, _col];
        float yPos = 4f;
        for (int i = 0; i < _row; ++i)
        {
            float xPos = 6f;
            for (int j = 0; j < _col; ++j)
            {
                _visited[i, j] = false;
                _roomX[i, j] = xPos;
                _roomY[i, j] = yPos;
                xPos += 12f;
            }
            yPos += 8f;
        }
    }

    private void FindSolutionPathRooms(int x, int y, bool firstEntry)
    {
        _visited[x, y] = true;
        // if reach top row -> place exit room
        if (x + 1 == _row)
        {
            _indexOfRoom[x, y] = (int)IndexRoom.exit;
            return;
        }

        _indexOfRoom[x, y] = 1;
        // if first entry -> place bottom room
        if (firstEntry == true)
            _indexOfRoom[x, y] = (int)IndexRoom.lrbot;
        // if first entry and first floor -> place top room
        if (firstEntry == true && x == 0)
            _indexOfRoom[x, y] = (int)IndexRoom.lrtop;

        int direction = Random.Range(1, 6);
        // move left
        if (direction == 1 || direction == 2)
        {
            // if can not move left -> try move right
            if (y - 1 < 0 || _visited[x, y - 1] == true)
            {
                if (direction == 1)
                    direction = 3;
                else
                    direction = 4;
            }
            else
            {
                FindSolutionPathRooms(x, y - 1, false);
            }
        }
        // move right
        if (direction == 3 || direction == 4)
        {
            // if can not move right -> try move up
            if (y + 1 == _col || _visited[x, y + 1] == true)
                direction = 5;
            else
            {
                FindSolutionPathRooms(x, y + 1, false);
            }
        }
        // move up
        if (direction == 5)
        {
            // if first entry -> place cross room
            if (firstEntry == true)
                _indexOfRoom[x, y] = (int)IndexRoom.cross;
            else // else place top room
                _indexOfRoom[x, y] = (int)IndexRoom.lrtop;
            FindSolutionPathRooms(x + 1, y, true);
        }
    }

    private void GenerateRooms(string parentDir)
    {
        for (int i = 0; i < _row; ++i)
            for (int j = 0; j < _col; ++j)
                if (_visited[i, j] == false)
                    GenerateRoom(
                        Random.Range(0, prefabRooms.Count - 1),
                        _roomX[i, j],
                        _roomY[i, j],
                        parentDir
                    );
                else
                    GenerateRoom(_indexOfRoom[i, j], _roomX[i, j], _roomY[i, j], parentDir);
    }

    private void GenerateRoom(int index, float xPos, float yPos, string parentDir)
    {
        GameObject room = prefabRooms[index];
        room = Instantiate(room, new Vector2(xPos, yPos), prefabRooms[index].transform.rotation);
        room.transform.parent = GameObject.Find(parentDir).transform;
    }
}

public enum IndexRoom
{
    closed,
    lr,
    lrbot,
    lrtop,
    cross,
    exit,
};
