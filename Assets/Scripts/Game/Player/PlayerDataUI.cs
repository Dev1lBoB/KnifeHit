using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerDataUI : MonoBehaviour
{
    [SerializeField]
    private Text balanceUI;
    [SerializeField]
    private Text scoreUI;
    [SerializeField]
    private Text stageUI;
    [SerializeField]
    private Text bestResultUI;

    private string defaultScoreText;
    private string defaultStageText;

    private void Start()
    {
        defaultScoreText = scoreUI.text;
        defaultStageText = stageUI.text;
    }

    public void UpdateBalance(string newBalance)
    {
        balanceUI.text = newBalance;
    }

    public void UpdateScore(string newScore)
    {
        scoreUI.text = newScore;
    }

    public void UpdateStage(string newStage)
    {
        stageUI.text = "STAGE " + newStage;
    }

    public void UpdateBestResult(int newBestScore, int newBestStage)
    {
        bestResultUI.text = "STAGE " + newBestStage + " - " + "SCORE " + newBestScore;
    }

    public void Reset()
    {
        scoreUI.text = defaultScoreText;
        stageUI.text = defaultStageText;
    }
}
