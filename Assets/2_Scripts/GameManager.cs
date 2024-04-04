using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private int maxScore;
    private int score;

    private void Awake()
    {
        Instance = this;
    }
    public void CalculateScore(bool isApple)
    {
       if (isApple)
        {
            score++;
            
        }else
        {
            score--;
        }
       UiManager.instance.OnScoreChange(this.score, maxScore);
    }

}
