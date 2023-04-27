using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoomInfo", menuName = "ScriptableObjects/RoomInfo", order = 0)]
public class RoomInfo : ScriptableObject {
    public int rows = 8;
    public int cols = 12;    
}

