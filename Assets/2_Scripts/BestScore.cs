using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class BestScore : MonoBehaviour
{
    public static BestScore Instance;
    public static int Score = 0;
    public static int besttime = 0;
    TextMeshProUGUI uiText;


    void Start()
    {
        uiText = GetComponent<TextMeshProUGUI>();
        besttime = 0;
    }

    void Update()
    {
        uiText.text = besttime.ToString();
    }
}
