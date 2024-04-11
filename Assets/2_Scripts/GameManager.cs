using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private int maxScore;
    [SerializeField] private int NoteGroupCreateScore;
   
    private int score;
    private int nextNoteGroupUnlockCnt;

    [SerializeField] private float maxtime = 30f;

    private void Awake()
    {
        Instance = this;
    }
    public void CalculateScore(bool isApple)
    {
       if (isApple)
        {
            score++;
            nextNoteGroupUnlockCnt++;
            if (NoteGroupCreateScore <= nextNoteGroupUnlockCnt)
            {
                nextNoteGroupUnlockCnt = 0;
                NoteManager.Instance.CreateNoteGroup();
            }
            
        }else
        {
            score--;
            nextNoteGroupUnlockCnt--;
        }
        UiManager.instance.OnScoreChange(this.score, maxScore);
    }
    private void Start()
    {
        UiManager.instance.OnScoreChange(this.score, maxScore);
        NoteManager.Instance.Create();

        StartCoroutine(TimeCouroutine());
    }

    IEnumerator TimeCouroutine()
    {
        float currentTime = 0;
        while (currentTime < maxScore)
        {

            currentTime += Time.deltaTime;
            UiManager.instance.OnTimerChange(currentTime, maxtime);
            yield return null;
        }
    }

}
