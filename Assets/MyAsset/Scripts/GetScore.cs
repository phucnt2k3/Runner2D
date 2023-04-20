using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GetScore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int highestScore = PlayerPrefs.GetInt("Score");
        GetComponent<TextMeshProUGUI>().SetText("Highest Score: " + highestScore);
    }

    // Update is called once per frame
    void Update() { }
}
