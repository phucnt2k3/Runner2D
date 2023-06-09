using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomGenerator : MineBehaviour
{
    private int _col = 4;
    public int Col => _col;
    private int _row = 4;
    public int Row => _row;
    private float[,] _roomX;
    private float[,] _roomY;
    private int[,] _indexOfRoom;
    private bool[,] _visited;
    private enum IndexRoom
    {
        closed,
        lr,
        lrbot,
        lrtop,
        cross,
        exit,
    };

    public void GenerateLevel(int level)
    {
        if (level < 3)
            _row = 2;
        else if (level < 5)
            _row = 3;
        else
            _row = 4;
        _col = _row;
        Init();
        FindSolutionPathRooms(0, 0, true);
        GenerateRooms();
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
                _roomX[i, j] = xPos + 0.5f;
                _roomY[i, j] = yPos + 0.5f;
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

    private void GenerateRooms()
    {
        for (int i = 0; i < _row; ++i)
            for (int j = 0; j < _col; ++j)
            {
                int roomIndex = _indexOfRoom[i, j];

                if (_visited[i, j] == false)
                    roomIndex = RoomSpawner.Instance.RandomNotExitRoomIndex();

                GenerateRoom(roomIndex, _roomX[i, j], _roomY[i, j]);
            }
    }

    private void GenerateRoom(int index, float xPos, float yPos)
    {
        Vector3 position = new Vector3(xPos, yPos, -1);
        RoomSpawner.Instance.SpawnRoom(index, position, Quaternion.identity);
    }
}
