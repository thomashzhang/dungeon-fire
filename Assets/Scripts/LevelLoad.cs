using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoad : MonoBehaviour
{
    [SerializeField] int timeToWait = 3;
    int currentSceneIndex;
    private Color loadToColor;
    private float loadDelay;
    // Start is called before the first frame update
    void Start()
    {
        loadToColor = Color.black;
        loadDelay = 5f;
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

    //public void LoadNextScene()
    //{
    //    Initiate.Fade(currentSceneIndex + 1, loadToColor, loadDelay);
    //}

    public void LoadScene(string sceneName)
    {
        Initiate.Fade(sceneName, loadToColor, loadDelay);
    }

    public void LoadStartScreen()
    {
        Initiate.Fade("Start Screen", loadToColor, loadDelay);
    }

    public void LoadLevelSelectScreen()
    {
        Initiate.Fade("Level Select Screen", loadToColor, loadDelay);
    }

    public void ReloadCurrentScren()
    {
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
