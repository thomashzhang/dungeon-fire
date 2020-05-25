using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LivesDisplay : MonoBehaviour
{
    private int initialLives;
    private int remainingLives;
    TextMeshProUGUI livesCountText;

    private bool gameLost;
    // Start is called before the first frame update
    void Start()
    {
        initialLives = PlayerPrefsManager.Lives;
        remainingLives = initialLives;
        livesCountText = GetComponent<TextMeshProUGUI>();
        UpdateLivesDisplay();
        gameLost = false;
    }

    private void UpdateLivesDisplay()
    {
        livesCountText.text = remainingLives.ToString();
    }

    public void AttackerReachedBase(int livesValue = 1)
    {
        if (!gameLost)
        {
            remainingLives -= livesValue;
            UpdateLivesDisplay();

            if (remainingLives <= 0)
            {
                gameLost = true;
                FindObjectOfType<LevelController>().LevelLose();
                remainingLives = 0;
            }
        }
    }

    public float LivesLostRatio()
    {
        return remainingLives / (float) initialLives;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
