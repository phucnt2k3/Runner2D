using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerInfoSO", menuName = "ScriptableObjects/PlayerInfoSO", order = 0)]
public class PlayerInfoSO : ScriptableObject
{
    public string namePlayer;
    public float jumpForce;
    public float moveSpeed;
}
