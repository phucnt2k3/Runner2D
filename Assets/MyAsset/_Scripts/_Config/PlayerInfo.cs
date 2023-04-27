using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfo", menuName = "ScriptableObjects/PlayerInfo", order = 0)]
public class PlayerInfo : ScriptableObject {
    public string namePlayer;
    public float jumpForce;
    public float moveSpeed;
}
