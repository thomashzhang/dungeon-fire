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
    [SerializeField] int gameStartDelaySeconds = 5;
    private GameTimer timer;
    private bool levelTimerFinished;
    public int AttackerCount { get; set; }
    private bool winInitiated;
    private bool gameStartInitiated;
    public bool TriggeredLevelWin { get; set; }
    public bool TriggeredLevelLose { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        StopSpawners();
        timer = FindObjectOfType<GameTimer>();
        AttackerCount = 0;
        levelTimerFinished = false;
        winCanvas.SetActive(false);
        loseCanvas.SetActive(false);
        winInitiated = false;
        gameStartInitiated = false;
        TriggeredLevelLose = false;
        TriggeredLevelWin = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameStartInitiated && Time.timeSinceLevelLoad >= gameStartDelaySeconds)
        {
            StartSpwaners();
            gameStartInitiated = true;
        }
        if (!winInitiated && levelTimerFinished && AttackerCount <= 0)
        {
            StartCoroutine(HandleLevelWin());
            winInitiated = true;
        }
    }

    public void AttackerSpawned()
    {
        AttackerCount += 1;
    }
    public void AttackerKilled()
    {
        AttackerCount -= 1;
    }

    private IEnumerator HandleLevelWin()
    {
        TriggeredLevelWin = true;
        UpdateRubiesEarned();
        yield return new WaitForSeconds(1);
        FindObjectOfType<MusicManager>().StopMusic();
        winCanvas.SetActive(true);
    }

    private void UpdateRubiesEarned()
    {
        var rubiesEarned = FindObjectOfType<RubiesEarned>();
        if (rubiesEarned != null)
        {
            rubiesEarned.TriggerLevelWinAddRubies();
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
        StopSpawners();
        yield return new WaitForSeconds(1);
        FindObjectOfType<MusicManager>().StopMusic();
        loseCanvas.SetActive(true);
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
