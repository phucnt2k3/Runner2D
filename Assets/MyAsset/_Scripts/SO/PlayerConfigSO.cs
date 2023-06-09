using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerConfigSO", menuName = "ScriptableObjects/PlayerConfigSO", order = 0)]
public class PlayerConfigSO : ScriptableObject
{
    public string namePlayer;
    public int maxHP = 3;
    public float jumpForce;
    public float moveSpeed;
}
