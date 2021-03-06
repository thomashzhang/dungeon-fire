﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
    [SerializeField] int timeToWait = 3;
    int currentSceneIndex;
    private Color loadToColor;
    private float loadDelayMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        loadToColor = Color.black;
        loadDelayMultiplier = 10f;
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (currentSceneIndex == 0)
        {
            StartCoroutine(WaitForTime());
        }
    }

    private IEnumerator WaitForTime()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadStartScreen();
    }

    public void PauseGame()
    {
        var levelController = FindObjectOfType<LevelController>();
        if (levelController != null)
        {
            levelController.PauseGame();
        }
    }

    public void LoadNextScene()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        // Initiate.Fade(currentSceneIndex + 1, loadToColor, loadDelay);
    }

    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
        // Initiate.Fade(sceneName, loadToColor, loadDelayMultiplier);
    }

    public void LoadStartScreen()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start Screen");
        // Initiate.Fade("Start Screen", loadToColor, loadDelayMultiplier);
    }

    public void LoadLevelSelectScreen()
    {
        Time.timeScale = 1;
        Initiate.Fade("Level Select Screen", loadToColor, loadDelayMultiplier);
    }

    public void ReloadCurrentScren()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
