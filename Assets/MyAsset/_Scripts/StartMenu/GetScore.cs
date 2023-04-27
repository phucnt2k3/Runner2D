using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetScore : MonoBehaviour
{
    void Awake()
    {
        int highestScore = PlayerPrefs.GetInt("Score");
        GetComponent<TextMeshProUGUI>().SetText("Highest Scores: " + highestScore);
    }
}
