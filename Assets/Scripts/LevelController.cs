using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winCanvas;
    [SerializeField] GameObject loseCanvas;
    [SerializeField] GameObject pauseCanvas;
    [SerializeField] int gameStartDelaySeconds = 5;
    [SerializeField] int gameLevel = 0;
    private GameTimer timer;
    private LivesDisplay lives;
    private bool levelTimerFinished;
    public int AttackerCount { get; set; }
    private bool winInitiated;
    private bool gameStartInitiated;
    public bool TriggeredLevelWin { get; set; }
    public bool TriggeredLevelLose { get; set; }

    public bool DeleteMercenaryModeEnabled { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        StopSpawners();
        gameStartDelaySeconds += PlayerPrefsManager.Prep;
        timer = FindObjectOfType<GameTimer>();
        lives = FindObjectOfType<LivesDisplay>();
        AttackerCount = 0;
        levelTimerFinished = false;
        winCanvas.SetActive(false);
        loseCanvas.SetActive(false);
        pauseCanvas.SetActive(false);
        winInitiated = false;
        gameStartInitiated = false;
        TriggeredLevelLose = false;
        TriggeredLevelWin = false;
        DeleteMercenaryModeEnabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStartInitiated && Time.timeSinceLevelLoad >= gameStartDelaySeconds)
        {
            StartSpwaners();
            gameStartInitiated = true;
        }
        if (!winInitiated && levelTimerFinished && AttackerCount <= 0 && lives.RemainingLives() > 0)
        {
            StartCoroutine(HandleLevelWin());
            winInitiated = true;
        }
    }

    public int GetGameLevel()
    {
        return gameLevel;
    }
    public void AttackerSpawned()
    {
        AttackerCount += 1;
    }
    public void AttackerKilled()
    {
        AttackerCount -= 1;
    }

    public void PauseGame()
    {
        pauseCanvas.SetActive(true);
    }

    private IEnumerator HandleLevelWin()
    {
        TriggeredLevelWin = true;
        UpdateRubiesEarned();
        if (gameLevel <= 0)
        {
            Debug.LogError("Game Level not set, unable to unlock levels");
        }
        else
        {
            UnlockLevels();
        }
        yield return new WaitForSeconds(1);
        FindObjectOfType<MusicManager>().StopMusic();
        winCanvas.SetActive(true);
    }

    private void UpdateRubiesEarned()
    {
        var rubiesEarned = FindObjectOfType<RubiesEarned>();
        if (rubiesEarned != null)
        {
            rubiesEarned.TriggerLevelEndAddRubiesToPlayerPrefs();
        }
        else
        {
            Debug.LogWarning("Can't find rubies object and not earning rubies for this level");
        }
    }

    public void LevelLose()
    {
        StartCoroutine(HandleLevelLose());
    }

    private IEnumerator HandleLevelLose()
    {
        TriggeredLevelLose = true;
        UpdateRubiesEarned();
        StopSpawners();
        yield return new WaitForSeconds(1);
        FindObjectOfType<MusicManager>().StopMusic();
        loseCanvas.SetActive(true);
    }

    private void UnlockLevels()
    {
        var maxLevelsUnlocked = PlayerPrefsManager.MaxLevelsUnlocked;
        if (maxLevelsUnlocked < (gameLevel + 1))
        {
            PlayerPrefsManager.MaxLevelsUnlocked = gameLevel + 1;
        }
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StartSpwaners()
    {
        var spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (var spawner in spawners)
        {
            spawner.SetSpawn(true);
        }
    }

    private void StopSpawners()
    {
        var spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (var spawner in spawners)
        {
            spawner.SetSpawn(false);
        }
    }

    public int GetGameStartDelaySeconds()
    {
        return gameStartDelaySeconds;
    }
    public bool GetGameStartInitiated()
    {
        return gameStartInitiated;
    }
}
