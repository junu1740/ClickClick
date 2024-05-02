using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class CurrentScore : MonoBehaviour
{





    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "BestScore :" + BestScore.besttime;
    }

    void Update()
    {
        
    }
}
