using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyInfoSO", menuName = "ScriptableObjects/EnemyInfoSO", order = 0)]
public class EnemyInfoSO : ScriptableObject
{
    public string nameEnemy;
    public float jumpForce;
    public float moveSpeed;
}
