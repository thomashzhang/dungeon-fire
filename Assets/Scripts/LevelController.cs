using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject winCanvas;
    [SerializeField] GameObject loseCanvas;
    private GameTimer timer;
    private bool levelTimerFinished;
    private int attackerCount;
    private bool winInitiated;
    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<GameTimer>();
        attackerCount = 0;
        levelTimerFinished = false;
        winCanvas.SetActive(false);
        loseCanvas.SetActive(false);
        winInitiated = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (timer.TimerOver() && FindObjectsOfType<Attacker>().Count() <= 0)
        //{
        //    SceneManager.LoadScene("Start Screen");
        //}        
        if (!winInitiated && levelTimerFinished && attackerCount <= 0)
        {
            StartCoroutine(HandleLevelWin());
            winInitiated = true;
        }
    }

    public void AttackerSpawned()
    {
        attackerCount += 1;
    }
    public void AttackerKilled()
    {
        attackerCount -= 1;
    }

    private IEnumerator HandleLevelWin()
    {
        yield return new WaitForSeconds(1);
        winCanvas.SetActive(true);
    }

    public void LevelLose()
    {
        StartCoroutine(HandleLevelLose());
    }

    private IEnumerator HandleLevelLose()
    {
        yield return new WaitForSeconds(1);
        loseCanvas.SetActive(true);
    }

    public void LevelTimerFinished()
    {
        levelTimerFinished = true;
        StopSpawners();
    }

    private void StopSpawners()
    {
        var spawners = FindObjectsOfType<AttackerSpawner>();
        foreach (var spawner in spawners)
        {
            spawner.SetSpawn(false);
        }
    }
}
