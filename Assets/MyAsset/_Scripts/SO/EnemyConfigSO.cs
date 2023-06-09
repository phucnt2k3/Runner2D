using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyConfigSO", menuName = "ScriptableObjects/EnemyConfigSO", order = 0)]
public class EnemyConfigSO : ScriptableObject
{
    public string nameEnemy;
    public int maxHP;
    public float jumpForce;
    public float moveSpeed;
}
