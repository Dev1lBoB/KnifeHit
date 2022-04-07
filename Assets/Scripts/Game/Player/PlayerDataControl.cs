using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

[RequireComponent(typeof(PlayerData))]
public class PlayerDataControl : MonoBehaviour
{
    private PlayerData playerData;

    [SerializeField]
    private PlayerDataUI playerDataUI;

    private string defaultScoreText;
    private string defaultStageText;

    private void Start()
    {
        playerData = GetComponent<PlayerData>();

        HitEvent.AppleHitted += AppleHitted;
        HitEvent.KnifeLanded += KnifeLanded;
        HitEvent.LevelPassed += LevelPassed;
        HitEvent.KnifeMissed += SaveResult;

        UpdateAllUI();
    }

    private void OnApplicationQuit()
    {
        SaveResult();
    }

    private void UpdateAllUI()
    {
        UpdateBalanceUI();
        UpdateScoreUI();
        UpdateStageUI();
        UpdateBestResultUI();
    }

    private void UpdateBalanceUI()
    {
        playerDataUI.UpdateBalance(playerData.balance.ToString());
    }

    private void UpdateScoreUI()
    {
        playerDataUI.UpdateScore(playerData.currentScore.ToString());
    }

    private void UpdateStageUI()
    {
        playerDataUI.UpdateStage(playerData.currentStage.ToString());
    }

    private void UpdateBestResultUI()
    {
        playerDataUI.UpdateBestResult(playerData.bestScore, playerData.bestStage);
    }

    private void SaveResult()
    {
        if (playerData.currentScore > playerData.bestScore)
        {
            playerData.bestScore = playerData.currentScore;
        }
        if (playerData.currentStage > playerData.bestStage)
        {
            playerData.bestStage = playerData.currentStage;
        }
    }

    private void AppleHitted()
    {
        playerData.balance += 2;
        UpdateBalanceUI();
    }
    
    private void KnifeLanded()
    {
        ++playerData.currentScore;
        UpdateScoreUI();
    }

    private void LevelPassed()
    {
        ++playerData.currentStage;
        UpdateStageUI();
    }

    public void Restart()
    {
        playerDataUI.Reset();

        playerData.currentScore = 0;
        playerData.currentStage = 1;
    }

    private void OnDestroy()
    {
        HitEvent.AppleHitted -= AppleHitted;
        HitEvent.KnifeLanded -= KnifeLanded;
        HitEvent.LevelPassed -= LevelPassed;
        HitEvent.LevelPassed -= SaveResult;
    }
}
