using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    [SerializeField] private Image scoreImg;
    [SerializeField] private TextMeshProUGUI scoreTmp;

    private void Awake()
    {
        instance = this;
    }

    public void OnScoreChange(int currentScore, int maxScore)
    {
        scoreTmp.text = $"{currentScore}/{maxScore}";
        scoreImg.fillAmount = (float)currentScore / maxScore;
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
