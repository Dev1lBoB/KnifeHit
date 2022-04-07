using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [System.Serializable]
    private struct Level
    {
        public int                  numOfKnives;
        public float                motorMaxTorque;
        public RotationElement[]    logRotationPattern;
        public GameObject           logPrefab;
    }

    [SerializeField]
    private Level[] levels;

    [SerializeField]
    private GameObject knifePrefab;

    [SerializeField]
    private KnivesPanel knivesPanel;
    [SerializeField]
    private GameObject  gameOverPanel;

    [SerializeField]
    private float delayBeforeNextLevel = 0.75f;

    private int         lvlNumber;
    private int         knifeCount;
    private GameObject  currentLog;

    private void Awake()
    {
        HitEvent.KnifeLanded += KnifeLanded;
        HitEvent.KnifeMissed += KnifeMissed;
    }

    private void SetUpLog(LogRotation logRotation, Level lvl)
    {
        // Prepares log to work
        logRotation.rotationPattern = lvl.logRotationPattern;
        logRotation.SetMotorTorque(lvl.motorMaxTorque);
        logRotation.LaunchMotor();
    }

    private void SetUpKnives(Level lvl)
    {
        // Prepares knives to work
        knifeCount = lvl.numOfKnives;
        knivesPanel.UpdatePanel(knifeCount);
    }

    private void LoadLevel(Level lvl)
    {
        // Spwans new log and prepares everything for the next lvl
        currentLog = Instantiate(lvl.logPrefab);
        LogRotation logRotation = currentLog.transform.GetComponentInChildren<LogRotation>();

        SetUpLog(logRotation, lvl);
        SetUpKnives(lvl);

        ++lvlNumber;
    }

    public void StartGame()
    {
        lvlNumber = 0;
        LoadLevel(levels[lvlNumber]);
    }

    private void SpawnKnife()
    {
        Instantiate(knifePrefab);
    }

    private IEnumerator LoadNextLevel()
    {
        // Blows up current log, and loads the next level
        HitEvent.CallLevelPassed();
        currentLog.GetComponent<LogBlowUp>().BlowUp();
        if (lvlNumber == levels.Length)
        {
            lvlNumber = 0;
        }
        yield return new WaitForSeconds(delayBeforeNextLevel);
        LoadLevel(levels[lvlNumber]);
        SpawnKnife();
    }

    private void KnifeLanded()
    {
        // Rigisters every landed to the log knife
        --knifeCount;
        if (knifeCount == 0)
        {
            // When player landed the last knife proceeds to load the next level
            StartCoroutine(LoadNextLevel());
        }
        else
        {
            SpawnKnife();
        }
    }

    private void KnifeMissed()
    {
        // Game Over
        knivesPanel.gameObject.SetActive(false);
        gameOverPanel.SetActive(true);
    }

    public void RestartGame()
    {
        Destroy(currentLog);
        StartGame();
        SpawnKnife();
    }

    private void OnDestroy()
    {
        HitEvent.KnifeLanded -= KnifeLanded;
        HitEvent.KnifeMissed -= KnifeMissed;
    }
}
