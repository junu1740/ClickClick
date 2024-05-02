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

    private int nextNoteGroupUnlockCnt;

    [SerializeField] private float maxtime = 30f;
    [HideInInspector] public float myTime;
    [HideInInspector] public float minTime;



    public bool isGameClear;
    public bool isGameOver;

    public bool IsGameDone
    {
        get
        {
            if (isGameClear || isGameOver)
            {
                minTime = PlayerPrefs.GetFloat("minTime", 1000f);
                if (minTime >= myTime)
                {
                    minTime = myTime;
                    PlayerPrefs.SetFloat("minTime", minTime);
                }

                SceneManager.LoadScene("Close");
                return true;
            }
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
            BestScore.Score++;
            nextNoteGroupUnlockCnt++;
            if (NoteGroupCreateScore <= nextNoteGroupUnlockCnt)
            {
                nextNoteGroupUnlockCnt = 0;
                NoteManager.Instance.CreateNoteGroup();
            }

            if (maxScore <= BestScore.Score)
            {
                SceneManager.LoadScene(3);
                Debug.Log("GameClear!...............");
            }





        }
        else
        {
            BestScore.Score--;
            nextNoteGroupUnlockCnt--;
        }
        UiManager.instance.OnScoreChange(BestScore.Score, maxScore);
    }



    private void Start()
    {
        UiManager.instance.OnScoreChange(BestScore.Score, maxScore);
        NoteManager.Instance.Create();


        gameClearObj.SetActive(false);

        StartCoroutine(TimeCouroutine());
    }

    IEnumerator TimeCouroutine()
    {
        float currentTime = 0;
        while (currentTime < maxtime)
        {
            myTime = currentTime;
            currentTime += Time.deltaTime;
            UiManager.instance.OnTimerChange(currentTime, maxtime);
            yield return null;

            if (IsGameDone)
            {
                yield break;
            }
        }



        SceneManager.LoadScene(2);



        if (BestScore.Score > BestScore.besttime)
        {
            BestScore.besttime = BestScore.Score;
        }
    }

}
