using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "Score :" + BestScore.Score;
    }

    void Update()
    {
        
    }
}
