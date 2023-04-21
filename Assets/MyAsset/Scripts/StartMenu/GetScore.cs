using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetScore : MonoBehaviour
{
    void Awale()
    {
        int highestScore = PlayerPrefs.GetInt("Score");
        GetComponent<TextMeshProUGUI>().SetText("Highest Score: " + highestScore);
    }
}
