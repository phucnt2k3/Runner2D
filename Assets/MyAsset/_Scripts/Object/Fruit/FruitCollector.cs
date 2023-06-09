using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitCollector : MineBehaviour
{
    [Header("Fruit Collector")]
    [SerializeField] protected int collectedFruits = 0;
    public int CollectedFruits => collectedFruits;
    public void SetCollectedFruits(int amount) => collectedFruits += amount;

}
