using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField] private int maxScore;
    [SerializeField] private int NoteGroupCreateScore;
    [SerializeField] private GameObject gameOverObj;
    [SerializeField] private GameObject gameClearObj;
    private int score;
    private int nextNoteGroupUnlockCnt;

    [SerializeField] private float maxtime = 30f;
    public bool IsGameDone
    {
        get
        {
            if(gameClearObj.activeSelf || gameOverObj.activeSelf)
                return true;
            else
            return false;
            

            
        }
    }



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

            if (maxScore <= score) 
            {
                gameClearObj.SetActive(true);
                Debug.Log("GameClear!..............."); 
            }
             

            
            
        }else
        {
            score--;
            nextNoteGroupUnlockCnt--;
        }
        UiManager.instance.OnScoreChange(this.score, maxScore);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
        

    private void Start()
    {
        UiManager.instance.OnScoreChange(this.score, maxScore);
        NoteManager.Instance.Create();

        gameOverObj.SetActive(false);
        gameClearObj.SetActive(false);

        StartCoroutine(TimeCouroutine());
    }

    IEnumerator TimeCouroutine()
    {
        float currentTime = 0;
        while (currentTime < maxtime)
        {

            currentTime += Time.deltaTime;
            UiManager.instance.OnTimerChange(currentTime, maxtime);
            yield return null;

            if (IsGameDone)
            {
                yield break;
            }
        }
        SceneManager.LoadScene(2);
    }

}
